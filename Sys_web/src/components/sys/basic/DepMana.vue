<template>
  <div>
    <div>
      <el-input
        class="inputCls"
        placeholder="添加部门"
        suffix-icon="el-icon-plus"
        v-model="departName"
        size="small"
      >
      </el-input>
      <el-button
        type="primary"
        icon="el-icon-plus"
        circle
        size="small"
        @click="addDepart"
      ></el-button>
    </div>
    <div style="margin-top: 12px">
      <el-table
        :data="departList"
        stripe
        border
        style="width: 70%"
        size="small"
      >
        <el-table-column prop="departmentID" label="编号" width="50">
        </el-table-column>
        <el-table-column prop="departmentName" label="部门" width="90">
        </el-table-column>
        <el-table-column prop="departmentTel" label="电话" width="120">
        </el-table-column>
        <el-table-column prop="departmentEmail" label="邮箱" width="150">
        </el-table-column>
        <el-table-column prop="remarks" label="备注" width="200">
        </el-table-column>
        <el-table-column label="操作">
          <template slot-scope="scope">
            <el-button
              size="mini"
              @click="showDilogEdit(scope.$index, scope.row)"
              >编辑</el-button
            >
            <el-button
              size="mini"
              type="danger"
              @click="handleDelete(scope.$index, scope.row)"
              >删除</el-button
            >
          </template>
        </el-table-column>
      </el-table>
    </div>
    <el-dialog title="编辑部门信息" :visible.sync="DialogVisible" width="40%">
      <div>
        <el-form>
          <el-form-item label="部门ID">
            <el-tag type="success" size="small">{{
              Updatedepart.departmentID
            }}</el-tag>
          </el-form-item>
          <el-form-item label="部门名称">
            <el-input
              placeholder="请输入内容"
              v-model="Updatedepart.departmentName"
              clearable
              size="small"
              style="width: 250px"
            >
            </el-input>
          </el-form-item>
          <el-form-item label="部门电话">
            <el-input
              placeholder="请输入电话"
              v-model="Updatedepart.departmentTel"
              clearable
              size="small"
              style="width: 250px"
            >
            </el-input>
          </el-form-item>
          <el-form-item label="部门邮箱">
            <el-input
              placeholder="请输入邮箱"
              v-model="Updatedepart.departmentEmail"
              clearable
              size="small"
              style="width: 250px"
            >
            </el-input>
          </el-form-item>
          <el-form-item label="备注">
            <el-input
              placeholder="请输入内容"
              v-model="Updatedepart.remarks"
              clearable
              size="small"
              style="width: 400px; margin-left: 27px"
              type="textarea"
            >
            </el-input>
          </el-form-item>
        </el-form>
      </div>
      <span slot="footer" class="dialog-footer">
        <el-button @click="DialogVisible = false" size="small">取 消</el-button>
        <el-button type="primary" size="small" @click="update">确 定</el-button>
      </span>
    </el-dialog>
  </div>
</template>

<script>
export default {
  name: "DepMana",
  data() {
    return {
      departName: "",
      Updatedepart: {
        departmentId: -1,
        departmentName: "",
        departmentTel: "",
        departmentEmail: "",
        remarks: "",
      },
      departList: [],
      DialogVisible: false,
    };
  },
  mounted() {
    this.initDepartList();
  },
  methods: {
    addDepart() {
      if (this.departName.length > 0) {
        let depart = {
          DepartmentName: this.departName,
        };
        this.postRequest("/api/Department/AddDepartment", depart).then(
          (resp) => {
            if (resp) {
              this.departName = "";
              this.initDepartList();
            }
          }
        );
      } else {
        this.$message({
          message: "部门名称不能为空！",
          type: "warning",
        });
      }
    },
    update() {
      let parmars = {
        DepartmentID: this.Updatedepart.departmentID,
        DepartmentName: this.Updatedepart.departmentName,
        DepartmentTel: this.Updatedepart.departmentTel,
        DepartmentEmail: this.Updatedepart.departmentEmail,
        Remarks: this.Updatedepart.remarks,
      };
      this.putRequest("/api/Department/UpdateDepartment", parmars).then(
        (resp) => {
          if (resp) {
            this.initDepartList();
            this.DialogVisible = false;
          }
        }
      );
    },
    showDilogEdit(index, data) {
      Object.assign(this.Updatedepart, data);
      this.DialogVisible = true;
    },
    handleDelete(index, data) {
      this.$confirm("确认删除改项?", "提示", {
        confirmButtonText: "确定",
        cancelButtonText: "取消",
        type: "warning",
      })
        .then(() => {
          this.deleteRequest(
            "/api/Department/DeleteDepartment/?id=" + data.departmentID
          ).then((resp) => {
            if (resp) {
              this.initDepartList();
            }
          });
        })
        .catch(() => {
          this.$message({
            type: "info",
            message: "已取消",
          });
        });
    },
    initDepartList() {
      this.getRequest("/api/Department/GetAllDepartment").then((resp) => {
        if (resp) {
          this.departList = resp;
        }
      });
    },
  },
};
</script>
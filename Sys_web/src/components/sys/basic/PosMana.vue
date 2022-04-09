<template>
  <div>
    <div>
      <el-input
        class="inputCls"
        placeholder="添加职位"
        suffix-icon="el-icon-plus"
        v-model="pos.RoleName"
        size="small"
      >
      </el-input>
      <el-button
        type="primary"
        icon="el-icon-plus"
        circle
        size="small"
        @click="addRoleInfo"
      ></el-button>
    </div>
    <div class="tableMain">
      <el-table
        :data="roleInformation"
        stripe
        border
        style="width: 70%"
        size="small"
        @selection-change="handleSelectionChange"
      >
        <el-table-column type="selection" width="40"> </el-table-column>
        <el-table-column prop="roleID" label="编号" width="50">
        </el-table-column>
        <el-table-column prop="roleName" label="职位" width="120">
        </el-table-column>
        <el-table-column prop="createTime" label="创建时间" width="170">
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
      <el-button
        type="danger"
        plain
        size="small"
        :disabled="this.multipleSelection.length == 0"
        style="margin-top: 10px"
        @click="delArrList"
        >批量删除</el-button
      >
    </div>
    <el-dialog title="编辑职位信息" :visible.sync="DialogVisible" width="30%">
      <div>
        <el-tag>职位编号</el-tag
        ><span style="margin-left: 5%">{{ updatePos.roleID }}</span>
      </div>
      <div style="margin-top: 6px">
        <el-tag>职位名称</el-tag>
        <el-input
          placeholder="请输入内容"
          clearable
          v-model="updatePos.roleName"
          style="width: 200px; margin-left: 10px"
          size="small"
        >
        </el-input>
      </div>
      <div style="margin-top: 6px">
        <el-tag>职位备注</el-tag>
      </div>
      <div style="margin-top: 6px">
        <el-input
          type="textarea"
          autosize
          placeholder="备注"
          v-model="updatePos.remarks"
        >
        </el-input>
      </div>
      <span slot="footer" class="dialog-footer">
        <el-button @click="DialogVisible = false" size="small">取 消</el-button>
        <el-button type="primary" @click="updateRoleInfo" size="small"
          >确 定</el-button
        >
      </span>
    </el-dialog>
  </div>
</template>

<script>
export default {
  name: "PosMana",
  data() {
    return {
      pos: {
        RoleName: "",
      },
      roleInformation: [],
      DialogVisible: false,
      updatePos: {
        roleName: "",
        remarks: "",
      },
      multipleSelection: [],
    };
  },
  methods: {
    initRoleInfo() {
      this.getRequest("/api/RoleInfo/GetRoleInformation").then((resp) => {
        if (resp) {
          this.roleInformation = resp;
        }
      });
    },
    showDilogEdit(index, data) {
      Object.assign(this.updatePos, data);
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
            "/api/RoleInfo/DelRoleInformation/?RoleID=" + data.roleID
          ).then((resp) => {
            if (resp) {
              this.initRoleInfo();
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
    addRoleInfo() {
      if (this.pos.RoleName) {
        this.postRequest("/api/RoleInfo/AddRoleInformation", this.pos).then(
          (resp) => {
            this.initRoleInfo();
            this.pos.RoleName = "";
          }
        );
      } else {
        this.$message({
          message: "职位名称不能为空！",
          type: "warning",
        });
      }
    },
    updateRoleInfo() {
      this.putRequest(
        "/api/RoleInfo/UpdateRoleInformation",
        this.updatePos
      ).then((resp) => {
        this.initRoleInfo();
        this.DialogVisible = false;
      });
    },
    handleSelectionChange(val) {
      this.multipleSelection = val;
    },
    delArrList() {
      this.$confirm("确认删除多项?", "提示", {
        confirmButtonText: "确定",
        cancelButtonText: "取消",
        type: "warning",
      })
        .then(() => {
          let list = [];
          this.multipleSelection.forEach((item) => {
            list.push(item.roleID);
          });
          this.postRequest("/api/RoleInfo/DelRoleInformationArry/", list).then(
            (resp) => {
              if (resp) {
                this.initRoleInfo();
              }
            }
          );
        })
        .catch(() => {
          this.$message({
            type: "info",
            message: "已取消",
          });
        });
    },
  },
  mounted() {
    this.initRoleInfo();
  },
};
</script>

<style>
.inputCls {
  width: 20%;
  margin-right: 10px;
}
.tableMain {
  margin-top: 12px;
}
</style>
<template>
  <div>
    <div style="width: 90%">
      <div style="width: 60%; display: inline-block">
        <el-input
          placeholder="请输入员工姓名"
          v-model="searchPer"
          clearable
          size="small"
          style="width: 50%"
        >
          <i slot="prefix" class="el-input__icon el-icon-search"></i>
        </el-input>
        <el-button
          type="primary"
          plain
          size="small"
          style="margin-left: 15px"
          @click="queryUser"
          >搜索</el-button
        >
      </div>
      <div style="display: inline-block; float: right">
        <el-button type="success" plain size="small" @click="downloadExecl()"
          >导出数据</el-button
        >
        <el-button type="success" plain size="small" @click="showDilog"
          >添加员工</el-button
        >
      </div>
    </div>
    <div style="margin-top: 20px; width: 90%">
      <div>
        <template>
          <el-table
            border
            size="small"
            :data="userInformation"
            stripe
            @selection-change="handleSelectionChange"
          >
            <el-table-column type="selection" width="40"> </el-table-column>
            <el-table-column prop="userID" label="编号" width="80">
            </el-table-column>
            <el-table-column prop="name" label="姓名" width="120">
            </el-table-column>
            <el-table-column prop="email" label="联系地址" width="200">
            </el-table-column>
            <el-table-column prop="roleName" label="当前职位">
            </el-table-column>
            <el-table-column prop="departmentName" label="所在部门">
            </el-table-column>
            <el-table-column prop="registerTime" label="入职时间" width="180">
            </el-table-column>
            <el-table-column label="操作" width="250">
              <template slot-scope="scope">
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
        </template>
      </div>
      <div style="margin-top: 10px; float: right">
        <el-pagination
          :current-page="pageIndex"
          :page-sizes="[5, 10, 15, 20]"
          :page-size="pageSize"
          layout="total, sizes, prev, pager, next, jumper"
          :total="PageCount"
          @current-change="toPage"
          @size-change="pageSizeHandel"
        >
        </el-pagination>
      </div>
    </div>
    <el-dialog
      title="添加员工"
      :visible.sync="dialogVisible"
      width="50%"
      :before-close="handleClose"
    >
      <div
        style="
          display: flex;
          justify-content: space-around;
          align-items: center;
        "
      >
        <el-steps direction="vertical" :active="activeIndex">
          <el-step
            :title="item"
            v-for="(item, index) in userItem"
            :key="index"
          ></el-step>
        </el-steps>
        <el-input
          placeholder="请输入姓名"
          clearable
          v-model="userItemObj.name"
          size="small"
          v-show="activeIndex == 0"
          style="width: 200px"
        >
        </el-input>
        <el-input
          placeholder="请输入账号"
          clearable
          v-model="userItemObj.userName"
          size="small"
          v-show="activeIndex == 1"
          style="width: 200px"
        >
        </el-input>
        <el-input
          placeholder="请输入密码"
          clearable
          v-model="userItemObj.password"
          size="small"
          v-show="activeIndex == 2"
          style="width: 200px"
        >
        </el-input>
        <el-input
          placeholder="请输入邮箱"
          clearable
          v-model="userItemObj.email"
          size="small"
          v-show="activeIndex == 3"
          style="width: 200px"
        >
        </el-input>
        <el-autocomplete
          v-model="userItemObj.role"
          :fetch-suggestions="queryRoleSearchAsync"
          placeholder="点击选择职位"
          @select="handleSelectRole"
          size="small"
          style="width: 200px"
          v-show="activeIndex == 4"
        >
          <i class="el-icon-edit el-input__icon" slot="suffix"> </i>
          <template slot-scope="{ item }">
            <div class="roleName">{{ item.roleName }}</div>
            <span class="roleID" hidden>{{ item.roleID }}</span>
          </template>
        </el-autocomplete>
        <el-autocomplete
          v-model="userItemObj.dept"
          :fetch-suggestions="queryDeptSearchAsync"
          placeholder="点击选择部门"
          @select="handleSelectDept"
          size="small"
          style="width: 200px"
          v-show="activeIndex == 5"
        >
          <i class="el-icon-edit el-input__icon" slot="suffix"> </i>
          <template slot-scope="{ item }">
            <div class="departmentName">{{ item.departmentName }}</div>
            <span class="departmentID" hidden>{{ item.departmentID }}</span>
          </template>
        </el-autocomplete>
        <el-date-picker
          v-model="userItemObj.time"
          type="date"
          placeholder="选择日期"
          v-show="activeIndex == 6"
          size="small"
          style="width: 200px"
          format="yyyy-MM-dd"
        >
        </el-date-picker>
      </div>
      <span slot="footer" class="dialog-footer">
        <el-button @click="prev" size="small">{{
          activeIndex == 6 ? "取消" : "上一步"
        }}</el-button>
        <el-button type="primary" @click="next" size="small">{{
          activeIndex == 6 ? "提交" : "下一步"
        }}</el-button>
      </span>
    </el-dialog>
  </div>
</template>

<script>
export default {
  name: "PerEmp",
  data() {
    return {
      activeIndex: 0,
      dialogVisible: false,
      PerDialog: false,
      searchPer: "",
      userInformation: [],
      pageIndex: 1,
      pageSize: 5,
      PageCount: 0,
      multipleSelection: [],
      userItem: ["姓名", "账户", "密码", "邮箱", "职位", "部门", "加入时间"],
      userItemObj: {
        name: "",
        userName: "",
        password: "",
        email: "",
        role: "",
        roleID: 0,
        dept: "",
        deptID: 0,
        time: "",
      },
      roleList: [],
      deptList: [],
    };
  },
  mounted() {
    this.getUserInfo();
    this.initRoleList();
    this.initDeptList();
  },
  methods: {
    prev() {
      if (this.activeIndex == 0) {
        return;
      } else if (this.activeIndex == 6) {
        this.dialogVisible = false;
        return;
      }
      this.activeIndex--;
    },
    next() {
      if (this.activeIndex == 6) {
        this.addUser();
        return;
      }
      this.activeIndex++;
    },
    handleClose(done) {
      done();
    },
    showDilog() {
      this.userItemObj = {
        name: "",
        userName: "",
        password: "",
        email: "",
        role: "",
        roleID: 0,
        dept: "",
        deptID: 0,
        time: "",
      };
      this.activeIndex = 0;
      this.dialogVisible = true;
    },
    handleSelectionChange(val) {
      this.multipleSelection = val;
    },
    pageSizeHandel(size) {
      this.pageSize = size;
      this.pageIndex = 1;
      if (this.searchPer.length > 0) {
        this.queryUser();
      } else {
        this.getUserInfo();
      }
    },
    toPage(Index) {
      this.pageIndex = Index;
      if (this.searchPer.length > 0) {
        this.queryUser();
      } else {
        this.getUserInfo();
      }
    },
    getUserInfo() {
      this.getRequest(
        "/api/UserInfo/GetAllUserInformation/?pageIndex=" +
          this.pageIndex +
          "&pageSize=" +
          this.pageSize
      ).then((resp) => {
        if (resp) {
          this.userInformation = resp.list;
          this.PageCount = resp.pageCount;
        }
      });
    },
    initRoleList() {
      this.getRequest("/api/RoleInfo/GetRoleInformation").then((resp) => {
        if (resp) {
          this.roleList = resp;
        }
      });
    },
    initDeptList() {
      this.getRequest("/api/Department/GetAllDepartment").then((resp) => {
        if (resp) {
          this.deptList = resp;
        }
      });
    },
    queryRoleSearchAsync(queryString, cb) {
      var restaurants = this.roleList;
      cb(restaurants);
    },
    handleSelectRole(item) {
      this.userItemObj.role = item.roleName;
      this.userItemObj.roleID = item.roleID;
    },
    queryDeptSearchAsync(queryString, cb) {
      var restaurants = this.deptList;
      cb(restaurants);
    },
    handleSelectDept(item) {
      this.userItemObj.dept = item.departmentName;
      this.userItemObj.deptID = item.departmentID;
    },
    addUser() {
      let parmams = {
        userName: this.userItemObj.userName,
        userPassword: this.userItemObj.password,
        name: this.userItemObj.name,
        email: this.userItemObj.email,
        registerTime: this.userItemObj.time,
        roleID: this.userItemObj.roleID,
        departmentID: this.userItemObj.deptID,
      };
      this.postRequest("/api/UserInfo/AddUserInformation", parmams).then(
        (resp) => {
          if (resp) {
            this.getUserInfo();
            this.dialogVisible = false;
          }
        }
      );
    },
    handleDelete(index, data) {
      this.$confirm("确认删除改项?", "提示", {
        confirmButtonText: "确定",
        cancelButtonText: "取消",
        type: "warning",
      })
        .then(() => {
          this.deleteRequest(
            "/api/UserInfo/DelUser?UserID=" + data.userID
          ).then((resp) => {
            if (resp) {
              this.getUserInfo();
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
    delArrList() {
      this.$confirm("确认删除多项?", "提示", {
        confirmButtonText: "确定",
        cancelButtonText: "取消",
        type: "warning",
      })
        .then(() => {
          let list = [];
          this.multipleSelection.forEach((item) => {
            list.push(item.userID);
          });
          this.deleteRequest("/api/UserInfo/DelUserList", list).then((resp) => {
            if (resp) {
              this.getUserInfo();
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
    queryUser() {
      if (this.searchPer.length > 0) {
        this.getRequest(
          "/api/UserInfo/GetAllUserInformationWhere/?pageIndex=" +
            this.pageIndex +
            "&pageSize=" +
            this.pageSize +
            "&where=" +
            this.searchPer
        ).then((resp) => {
          if (resp) {
            this.userInformation = resp.list;
            this.PageCount = resp.pageCount;
          }
        });
      } else {
        this.getUserInfo();
      }
    },
    downloadExecl() {
      this.downloadRequest("/api/FileUpLoad/DownloadFile");
    },
  },
};
</script>
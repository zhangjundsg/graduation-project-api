<template>
  <div>
    <el-container>
      <el-header class="homeHeader">
        人员办公管理系统
        <el-dropdown @command="commandHeadler">
          <span class="el-dropdown-link">
            <span class="users">{{ user.name }}</span>
            <i><img :src="user.userImg" /></i>
          </span>
          <el-dropdown-menu slot="dropdown" class="user">
            <el-dropdown-item command="userinfo">个人中心</el-dropdown-item>
            <el-dropdown-item command="outlogin">退出</el-dropdown-item>
          </el-dropdown-menu>
        </el-dropdown>
      </el-header>
      <el-container class="containerH">
        <el-aside width="200px">
          <el-menu router unique-opened>
            <el-submenu
              :index="index + ''"
              v-for="(item, index) in routes"
              :key="index"
              v-if="!item.hidden"
            >
              <template slot="title">
                <i :class="item.iconCls" style="margin-right: 10px"></i>
                <span>{{ item.name }}</span>
              </template>
              <el-menu-item
                :index="children.path"
                v-for="(children, indexCd) in item.children"
              >
                {{ children.name }}
              </el-menu-item>
            </el-submenu>
          </el-menu>
        </el-aside>
        <el-main>
          <el-breadcrumb
            separator-class="el-icon-arrow-right"
            v-if="this.$router.currentRoute.path != '/home'"
          >
            <el-breadcrumb-item :to="{ path: '/home' }"
              >首页</el-breadcrumb-item
            >
            <el-breadcrumb-item>{{
              this.$router.currentRoute.name
            }}</el-breadcrumb-item>
          </el-breadcrumb>
          <router-view class="homeRouter" />
        </el-main>
      </el-container>
    </el-container>
    <el-dialog :visible.sync="dialogVisible" width="30%">
      <el-card
        class="box-card"
        shadow="hover"
        :body-style="{ padding: '10px' }"
        style="width: 100%"
      >
        <div slot="header">
          <span>{{ userInfo.name }}</span>
        </div>
        <div style="text-align: center">
          <img
            :src="userInfo.userImg"
            alt=""
            style="width: 80px; height: 80px; border-radius: 40px"
          />
        </div>
        <div style="margin-top: 8px; margin-left: 50px">
          职位标签：<el-tag size="small" type="success">{{
            role.roleName
          }}</el-tag>
        </div>
        <div style="margin-top: 8px; margin-left: 50px">
          部门标签：<el-tag type="danger" size="small">{{
            department.departmentName
          }}</el-tag>
        </div>
        <div style="margin-top: 8px; margin-left: 50px">
          部门电话：<el-tag type="danger" size="small">{{
            department.departmentTel
          }}</el-tag>
        </div>
        <div style="margin-top: 8px; margin-left: 50px">
          邮箱地址：<el-tag size="small">{{ userInfo.email }}</el-tag>
        </div>
        <div style="margin-top: 8px; margin-left: 50px">
          加入时间：<el-tag size="small">{{ userInfo.registerTime }}</el-tag>
        </div>
      </el-card>
    </el-dialog>
  </div>
</template>

<script>
export default {
  name: "Home",
  data() {
    return {
      user: JSON.parse(window.sessionStorage.getItem("userInfo")),
      dialogVisible: false,
      userInfo: {},
      department: {},
      role: {},
    };
  },
  computed: {
    routes() {
      return this.$store.state.routes;
    },
  },
  mounted() {
    this.initUserInfo();
  },
  methods: {
    initUserInfo() {
      let userid = window.sessionStorage.getItem("userid");
      this.getRequest(
        "/api/UserInfo/GetDetailUserInformation/?id=" + userid
      ).then((resp) => {
        if (resp) {
          this.userInfo = resp[0];
          this.department = resp[0].department;
          this.role = resp[0].role;
        }
      });
    },
    commandHeadler(command) {
      if (command == "outlogin") {
        this.$confirm("是否退出登录?", "提示", {
          confirmButtonText: "确定",
          cancelButtonText: "取消",
          type: "warning",
        })
          .then(() => {
            this.postRequest("/api/UserInfo/LoginOut");
            window.sessionStorage.removeItem("token");
            window.sessionStorage.removeItem("userInfo");
            window.sessionStorage.removeItem("userid");
            this.$store.commit("initRoutes", []);
            this.$router.replace("/");
          })
          .catch(() => {
            this.$message({
              type: "info",
              message: "已取消",
            });
          });
      } else if (command == "userinfo") {
        this.dialogVisible = true;
      }
    },
  },
};
</script>

<style>
.homeHeader {
  background-color: #409eff;
  display: flex;
  align-items: center;
  justify-content: space-between;
  padding: 0 15px;
  box-sizing: border-box;
  font-size: 25px;
  color: white;
  font-family: 华文楷体;
}
.user {
  cursor: pointer;
}
.el-dropdown-link img {
  width: 48px;
  height: 48px;
  border-radius: 24px;
  margin-left: 10px;
}
.users {
  font-weight: bold;
  font-size: 18px;
}
.homeRouter {
  margin-top: 12px;
}
.containerH {
  height: 800px;
}
</style>
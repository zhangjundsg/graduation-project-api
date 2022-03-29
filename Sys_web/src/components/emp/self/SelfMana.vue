<template>
  <div>
    <el-card class="box-card" shadow="hover">
      <div style="text-align: center">
        <img
          :src="userinfo.userImg"
          alt=""
          srcset=""
          title="点击更换头像"
          class="imgFace"
        />
      </div>
      <div style="margin-top: 30px">
        <div class="marginLe">
          <div style="display: inline-block">
            <el-tag type="success" effect="plain" size="small">姓名：</el-tag
            ><el-tag size="small" class="mrLeft">{{ userinfo.name }}</el-tag>
          </div>
          <div style="display: inline-block; float: right">
            <el-tag
              type="success"
              effect="plain"
              size="small"
              style="margin-right: 8px"
              >部门：</el-tag
            ><el-tag
              size="small"
              style="margin-right: 134px"
              v-if="userinfo.department && userinfo.department.departmentName"
              >{{ userinfo.department.departmentName }}</el-tag
            >
          </div>
        </div>
        <div style="margin-top: 15px" class="marginLe">
          <div style="display: inline-block">
            <el-tag type="success" effect="plain" size="small">职位：</el-tag
            ><el-tag
              size="small"
              class="mrLeft"
              v-if="userinfo.role && userinfo.role.roleName"
              >{{ userinfo.role.roleName }}</el-tag
            >
          </div>
          <div style="display: inline-block; float: right">
            <el-tag
              type="success"
              effect="plain"
              size="small"
              style="margin-right: 15px"
              >部门电话：</el-tag
            ><el-tag
              size="small"
              style="margin-right: 122px"
              v-if="userinfo.department && userinfo.department.departmentTel"
              >{{ userinfo.department.departmentTel }}</el-tag
            >
          </div>
        </div>
        <div style="margin-top: 15px" class="marginLe">
          <div style="display: inline-block">
            <el-tag type="success" effect="plain" size="small"
              >个人邮箱：</el-tag
            ><el-tag size="small" class="mrLeft">{{ userinfo.email }}</el-tag>
          </div>
          <div style="display: inline-block; float: right">
            <el-tag
              type="success"
              effect="plain"
              size="small"
              style="margin-right: 15px"
              >部门邮箱：</el-tag
            ><el-tag
              size="small"
              style="margin-right: 70px"
              v-if="userinfo.department && userinfo.department.departmentEmail"
              >{{ userinfo.department.departmentEmail }}</el-tag
            >
          </div>
        </div>
        <div style="margin-top: 15px" class="marginLe">
          <el-tag type="success" effect="plain" size="small">加入时间：</el-tag
          ><el-tag size="small" class="mrLeft">{{
            userinfo.registerTime
          }}</el-tag>
        </div>
      </div>
    </el-card>
  </div>
</template>

<script>
export default {
  name: "SelfMana",
  data() {
    return {
      userinfo: {},
    };
  },
  mounted() {
    this.initUserInfo();
  },
  methods: {
    initUserInfo() {
      let userid = window.sessionStorage.getItem("userid");
      this.getRequest(
        "/api/UserInfo/GetDetailUserInformation?id=" + userid
      ).then((resp) => {
        if (resp) {
          this.userinfo = resp[0];
        }
      });
    },
  },
};
</script>

<style>
.box-card {
  width: 65%;
}
.imgFace {
  width: 130px;
  height: 130px;
  border-radius: 65px;
}
.mrLeft {
  margin-left: 8px;
}
.marginLe {
  margin-left: 90px;
}
</style>
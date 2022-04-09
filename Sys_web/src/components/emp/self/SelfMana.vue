<template>
  <div>
    <el-card class="box-card" shadow="hover">
      <div style="text-align: center">
        <img :src="userinfo.userImg" alt="" srcset="" class="imgFace" />
      </div>
      <div style="margin-top: 40px">
        <el-descriptions :column="3" size="small" border>
          <el-descriptions-item>
            <template slot="label">
              <i class="el-icon-user"></i>
              姓名
            </template>
            <el-tag size="small">{{ userinfo.name }}</el-tag>
          </el-descriptions-item>
          <el-descriptions-item>
            <template slot="label">
              <i class="fa fa-envelope-o" aria-hidden="true"></i>
              邮箱
            </template>
            <el-tag size="small">{{ userinfo.email }}</el-tag>
          </el-descriptions-item>
          <el-descriptions-item>
            <template slot="label">
              <i class="fa fa-address-card-o" aria-hidden="true"></i>
              职位
            </template>
            <el-tag
              size="small"
              v-if="userinfo.role && userinfo.role.roleName"
              >{{ userinfo.role.roleName }}</el-tag
            >
          </el-descriptions-item>
          <el-descriptions-item>
            <template slot="label">
              <i class="fa fa-users" aria-hidden="true"></i>
              部门
            </template>
            <el-tag
              size="small"
              v-if="userinfo.department && userinfo.department.departmentName"
              >{{ userinfo.department.departmentName }}</el-tag
            >
          </el-descriptions-item>
          <el-descriptions-item>
            <template slot="label">
              <i class="fa fa-phone" aria-hidden="true"></i>
              部门电话
            </template>
            <el-tag
              size="small"
              v-if="userinfo.department && userinfo.department.departmentTel"
              >{{ userinfo.department.departmentTel }}</el-tag
            >
          </el-descriptions-item>
          <el-descriptions-item>
            <template slot="label">
              <i class="el-icon-office-building"></i>
              部门邮箱
            </template>
            <el-tag
              size="small"
              v-if="userinfo.department && userinfo.department.departmentEmail"
              >{{ userinfo.department.departmentEmail }}</el-tag
            >
          </el-descriptions-item>
        </el-descriptions>
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
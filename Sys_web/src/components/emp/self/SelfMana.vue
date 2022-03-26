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
      <div>
        姓名：<el-tag size="small">{{ userinfo.name }}</el-tag>
      </div>
      <div>
        个人邮箱：<el-tag size="small">{{ userinfo.email }}</el-tag>
      </div>
      <div>名称</div>
      <div>名称</div>
      <div>名称</div>
      <div>名称</div>
      <div>名称</div>
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
</style>
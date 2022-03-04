<template>
  <div>
    <el-form
      :rules="rules"
      ref="loginForm"
      :model="loginForm"
      class="LoginContainer"
      v-loading="loading"
      element-loading-text="正在登录。。。"
      element-loading-spinner="el-icon-loading"
      element-loading-background="rgba(0, 0, 0, 0.8)"
    >
      <h3 class="loginTitle">企业人员信息管理系统</h3>
      <el-form-item prop="username">
        <el-input type="text" v-model="loginForm.username" placeholder="账号">
        </el-input>
      </el-form-item>
      <el-form-item prop="password">
        <el-input
          type="password"
          v-model="loginForm.password"
          auto-complete="false"
          placeholder="密码"
        ></el-input>
      </el-form-item>
      <el-form-item prop="code">
        <el-input
          type="text"
          v-model="loginForm.code"
          auto-complete="false"
          placeholder="点击图片切换验证码"
          style="width: 200px; margin-right: 25px"
        ></el-input>
        <img :src="captchaUrl" @click="updateImg" />
      </el-form-item>
      <el-checkbox v-model="checked" class="loginRemember">记住我</el-checkbox>
      <el-button type="primary" style="width: 100%" @click="submitLogin"
        >登录</el-button
      >
    </el-form>
  </div>
</template>

<script>
export default {
  name: "Login",
  data() {
    return {
      captchaUrl: "/api/Captcha?time=" + new Date(),
      loginForm: {
        username: "",
        password: "",
        code: "",
      },
      loading: false,
      checked: true,
      rules: {
        username: [
          { required: true, message: "请输入账号！", trigger: "blur" },
        ],
        password: [
          { required: true, message: "请输入密码！", trigger: "blur" },
        ],
        code: [{ required: true, message: "请输入验证码！", trigger: "blur" }],
      },
    };
  },
  methods: {
    updateImg() {
      this.captchaUrl = "/api/Captcha?time=" + new Date();
    },
    submitLogin() {
      this.$refs.loginForm.validate((valid) => {
        this.loading = true;
        if (valid) {
          this.loading = false;
          this.postRequest(
            "/api/Authentication/RequestToken",
            this.loginForm
          ).then((resp) => {
            //存储token
            const token = resp.token;
            const userid = resp.userID;
            window.sessionStorage.setItem("token", token);
            window.sessionStorage.setItem("userid", userid);
            let path = this.$route.query.redirect;
            this.$router.replace(
              path == "/" || path == undefined ? "/home" : path
            );
          });
        } else {
          this.$message({
            showClose: true,
            message: "请输入所有字段",
            type: "error",
          });
          return false;
        }
      });
    },
  },
};
</script>
<style>
.LoginContainer {
  border-radius: 15px;
  background-clip: border-box;
  margin: 180px auto;
  width: 350px;
  padding: 15px 35px 15px 35px;
  background-color: rgb(250, 249, 248);
  border: 1px solid #f7f2f2;
  box-shadow: 0 0 20px #afacac;
}
.loginTitle {
  margin: 0px auto 40px auto;
  text-align: center;
  padding-top: 3%;
}
.loginRemember {
  text-align: left;
  margin: 0px 0px 15px 0px;
}
</style>
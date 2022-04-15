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
          show-password
        ></el-input>
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
        code: "asd123",
      },
      loading: false,
      checked: false,
      rules: {
        username: [
          { required: true, message: "请输入账号！", trigger: "blur" },
        ],
        password: [
          { required: true, message: "请输入密码！", trigger: "blur" },
        ],
      },
    };
  },
  mounted() {
    this.ischecked();
  },
  methods: {
    ischecked() {
      if (window.localStorage.getItem("username")) {
        this.loginForm.username = window.localStorage.getItem("username");
        this.loginForm.password = window.localStorage.getItem("password");
        this.checked = true;
      }
    },
    updateImg() {
      this.captchaUrl = "/api/Captcha?time=" + new Date();
    },
    submitLogin() {
      this.$refs.loginForm.validate((valid) => {
        this.loading = true;
        if (valid) {
          this.loading = false;
          if (this.checked) {
            window.localStorage.setItem("username", this.loginForm.username);
            window.localStorage.setItem("password", this.loginForm.password);
          } else {
            window.localStorage.removeItem("username");
            window.localStorage.removeItem("password");
          }
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
            if (path == "/" || path == undefined) {
              path = "/home";
            }
            this.$router.replace(path);
          });
        } else {
          this.$message({
            showClose: true,
            message: "请输入所有字段",
            type: "error",
          });
          this.loading = false;
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
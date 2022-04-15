<template>
  <div>
    <div>
      <el-card :body-style="{ padding: '0px' }" style="width: 30%">
        <img
          src="https://tse2-mm.cn.bing.net/th/id/OIP-C.PNnrZJXu4ovKCQZI89ZSRQHaHa?pid=ImgDet&rs=1"
          class="image"
          style="width: 100%; height: 350px"
        />
        <div style="padding: 14px; text-align: center">
          <span>
            <el-button
              type="primary"
              size="small"
              round
              @click="dialogVisible = true"
              >修改个人信息</el-button
            ></span
          >
        </div>
      </el-card>
    </div>
    <el-dialog
      title="密码修改"
      :visible.sync="dialogVisible"
      width="30%"
      :before-close="handleClose"
    >
      <div>
        <span style="font-weight: bold; margin-bottom: 20px">密码修改</span>
        <el-form
          :model="ruleForm"
          label-width="120px"
          :rules="rules"
          ref="ruleForm"
        >
          <el-form-item label="输入密码" prop="pass">
            <el-input
              type="password"
              v-model="ruleForm.pass"
              size="small"
              style="width: 200px"
              show-password
            ></el-input>
          </el-form-item>
          <el-form-item label="确认密码" prop="checkPass">
            <el-input
              type="password"
              v-model="ruleForm.checkPass"
              size="small"
              style="width: 200px"
              show-password
            ></el-input>
          </el-form-item>
        </el-form>
      </div>
      <span slot="footer" class="dialog-footer">
        <el-button @click="cancel" size="small">取 消</el-button>
        <el-button type="primary" @click="updatePass('ruleForm')" size="small"
          >确 定</el-button
        >
      </span>
    </el-dialog>
  </div>
</template>

<script>
export default {
  name: "InfoMana",
  data() {
    var validatePass = (rule, value, callback) => {
      if (value === "") {
        callback(new Error("请输入密码"));
      } else {
        if (this.ruleForm.checkPass !== "") {
          this.$refs.ruleForm.validateField("checkPass");
        }
        callback();
      }
    };
    var validatePass2 = (rule, value, callback) => {
      if (value === "") {
        callback(new Error("请再次输入密码"));
      } else if (value !== this.ruleForm.pass) {
        callback(new Error("两次输入密码不一致!"));
      } else {
        callback();
      }
    };
    return {
      dialogVisible: false,
      ruleForm: {
        pass: "",
        checkPass: "",
      },
      rules: {
        pass: [{ validator: validatePass, trigger: "blur" }],
        checkPass: [{ validator: validatePass2, trigger: "blur" }],
      },
    };
  },
  mounted() {},
  methods: {
    handleClose(done) {
      done();
    },
    updatePass(form) {
      this.$refs[form].validate((valid) => {
        if (valid) {
          let parmars = {
            UserID: parseInt(window.sessionStorage.getItem("userid")),
            UserPassword: this.ruleForm.pass,
          };
          this.putRequest("/api/UserInfo/UpdateUserPass", parmars).then(
            (resp) => {
              if (resp) {
                this.dialogVisible = false;
                this.ruleForm = {
                  pass: "",
                  checkPass: "",
                };
              }
            }
          );
        } else {
          return false;
        }
      });
    },
    cancel() {
      this.ruleForm = {
        pass: "",
        checkPass: "",
      };
      this.dialogVisible = false;
    },
  },
};
</script>
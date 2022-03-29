<template>
  <div>
    <div>
      <el-card :body-style="{ padding: '0px' }" style="width: 30%">
        <img
          src="https://bpic.588ku.com/art_origin_min_pic/19/03/21/8107adc4ffa23ba5e1833edc3a1a37ca.jpg"
          class="image"
          style="width: 100%; height: 350px"
        />
        <div style="padding: 14px; text-align: center">
          <span>
            <el-button type="primary" size="small" @click="showDialog" round
              >发送邮件</el-button
            ></span
          >
        </div>
      </el-card>
    </div>
    <div>
      <el-drawer
        title="邮件发送"
        :before-close="handleClose"
        :visible.sync="dialog"
        direction="ltr"
        custom-class="demo-drawer"
        ref="drawer"
      >
        <div style="margin-left: 8px">
          <div style="margin-top: 45px">
            <el-tag>收件人：</el-tag>
            <el-autocomplete
              v-model="state"
              :fetch-suggestions="querySearchAsync"
              placeholder="请输入收件人邮箱"
              @select="handleSelect"
              size="small"
              style="width: 70%; margin-left: 5px"
            >
              <i class="el-icon-edit el-input__icon" slot="suffix"> </i>
              <template slot-scope="{ item }">
                <div class="email">{{ item.email }}</div>
                <span class="name">{{ item.name }}</span>
              </template>
            </el-autocomplete>
          </div>
          <div style="margin-top: 8px">
            <el-tag style="width: 70px">主&nbsp;&nbsp;&nbsp;&nbsp;题：</el-tag>
            <el-input
              v-model="emailTitle"
              placeholder="请输入主题"
              size="small"
              style="width: 70%; margin-left: 5px"
              ><i class="el-icon-edit el-input__icon" slot="suffix"> </i
            ></el-input>
          </div>
          <div style="margin-top: 8px">
            <el-tag style="width: 70px">正&nbsp;&nbsp;&nbsp;&nbsp;文：</el-tag>
            <div style="margin-top: 3px; margin-left: 1px">
              <el-input
                type="textarea"
                :rows="13"
                placeholder="请输入正文"
                v-model="EmailText"
                style="width: 95%"
              >
              </el-input>
            </div>
          </div>
          <div style="margin-top: 15px">
            <el-tag style="width: 70px">附&nbsp;&nbsp;&nbsp;&nbsp;件：</el-tag>
          </div>
          <div
            class="demo-drawer__content"
            style="margin-top: 50px; float: right; margin-right: 25px"
          >
            <div>
              <el-button size="small" @click="cancelSend">取 消</el-button>
              <el-button
                type="primary"
                :loading="loading"
                @click="sendSysEmail"
                size="small"
                >{{ loading ? "发送中 ..." : "发 送" }}</el-button
              >
            </div>
          </div>
        </div>
      </el-drawer>
    </div>
  </div>
</template>

<script>
export default {
  name: "CommonMana",
  data() {
    return {
      dialog: false,
      loading: false,
      userEmailAll: [],
      state: "",
      emailTitle: "",
      EmailText: "",
      sendUser: "",
      toUser: "",
    };
  },
  mounted() {
    this.initEmailAll();
  },
  methods: {
    showDialog() {
      this.dialog = true;
    },
    querySearchAsync(queryString, cb) {
      var restaurants = this.userEmailAll;
      var results = queryString
        ? restaurants.filter(this.queryUserEmail(queryString))
        : restaurants;
      cb(results);
    },
    queryUserEmail(userName) {
      return (restaurant) => {
        return (
          restaurant.name.indexOf(userName) != -1 ||
          restaurant.email.indexOf(userName) != -1
        );
      };
    },
    initEmailAll() {
      let user = JSON.parse(window.sessionStorage.getItem("userInfo"));
      this.sendUser = user.name;

      this.getRequest("/api/UserInfo/GetUserEmailAll").then((resp) => {
        if (resp) {
          this.userEmailAll = resp;
        }
      });
    },
    handleSelect(item) {
      this.state = item.email;
      this.toUser = item.name;
    },
    handleClose(done) {
      done();
    },
    sendSysEmail() {
      if (this.state && this.emailTitle && this.EmailText) {
        this.loading = true;
        let SendEmail = {
          fromPersonName: this.sendUser,
          recipient: this.toUser,
          recipientArry: this.state,
          mailTitle: this.emailTitle,
          mailBody: this.EmailText,
        };
        this.postRequest("/api/SendEmail/Send", SendEmail).then((resp) => {
          if (resp) {
            this.loading = false;
            this.dialog = false;
            this.state = "";
            this.emailTitle = "";
            this.EmailText = "";
          }
        });
      } else {
        this.$message({
          message: "内容不完整！",
          type: "warning",
        });
      }
    },
    cancelSend() {
      this.dialog = false;
      this.state = "";
      this.emailTitle = "";
      this.EmailText = "";
    },
  },
};
</script>

<style>
.email {
  text-overflow: ellipsis;
  overflow: hidden;
}
.name {
  font-size: 12px;
  color: #b4b4b4;
}
</style>
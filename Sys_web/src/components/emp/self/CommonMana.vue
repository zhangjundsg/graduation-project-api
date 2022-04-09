<template>
  <div>
    <div style="width: 27%; display: inline-block">
      <el-card :body-style="{ padding: '0px' }">
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
    <div style="width: 27%; display: inline-block; margin-left: 15px">
      <el-card :body-style="{ padding: '0px' }">
        <img
          src="https://img.51miz.com/Element/00/77/63/09/9ea55f15_E776309_33cd7df7.png"
          class="image"
          style="width: 100%; height: 350px"
        />
        <div style="padding: 14px; text-align: center">
          <span>
            <el-button type="primary" size="small" @click="filedDialog" round
              >我的申请</el-button
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
            <el-upload
              style="width: 250px"
              ref="upload"
              action="api/FileUpLoad/UploadTemp"
              :headers="uploadHeader"
              :on-success="AddFiles"
              :on-remove="RemoveFile"
              :file-list="fileList"
            >
              <el-button slot="trigger" size="small" type="primary"
                >附&nbsp;&nbsp;&nbsp;&nbsp;件：</el-button
              >
            </el-upload>
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
    <div>
      <el-dialog title="我的申请" :visible.sync="outerVisible">
        <el-dialog width="30%" :visible.sync="innerVisibleZg" append-to-body>
          <el-form :model="formZg">
            <el-form-item label="当前岗位"
              ><el-tag type="info" size="small">{{
                formZg.thisRole
              }}</el-tag></el-form-item
            >
            <el-form-item label="预调整岗">
              <el-autocomplete
                v-model="formZg.filedRole"
                :fetch-suggestions="queryRoleAsync"
                placeholder="调整岗位"
                @select="filedSelect"
                size="small"
                style="width: 70%"
              >
                <i class="el-icon-edit el-input__icon" slot="suffix"> </i>
                <template slot-scope="{ item }">
                  <div class="email">{{ item.roleName }}</div>
                  <span class="name" hidden>{{ item.roleID }}</span>
                </template>
              </el-autocomplete>
            </el-form-item>
            <el-form-item label="换岗理由">
              <el-input
                type="textarea"
                :rows="3"
                v-model="formZg.filedText"
                style="width: 70%"
              ></el-input>
            </el-form-item>
            <el-form-item label="申请时间">
              <el-date-picker
                v-model="formZg.filedTime"
                type="datetime"
                placeholder="选择日期时间"
                default-time="12:00:00"
                size="small"
                style="width: 70%"
              >
              </el-date-picker>
            </el-form-item>
            <el-form-item label="申请人"
              ><el-tag size="small">{{ userName }}</el-tag>
            </el-form-item>
            <el-form-item>
              <el-button
                type="primary"
                size="small"
                style="float: right"
                @click="zgSub"
                >提交申请</el-button
              >
              <el-button
                size="small"
                style="float: right; margin-right: 10px"
                @click="innerVisibleZg = false"
                >取消</el-button
              >
            </el-form-item>
          </el-form>
        </el-dialog>
        <el-dialog width="30%" :visible.sync="innerVisibleQj" append-to-body>
          <el-form :model="formQj">
            <el-form-item label="请假时间">
              <el-date-picker
                v-model="formQj.filedTime"
                type="datetimerange"
                range-separator="至"
                start-placeholder="开始日期"
                end-placeholder="结束日期"
                style="width: 70%"
                size="small"
              >
              </el-date-picker>
            </el-form-item>
            <el-form-item label="请假理由">
              <el-input
                type="textarea"
                :rows="3"
                v-model="formQj.filedText"
                style="width: 70%"
              ></el-input>
            </el-form-item>
            <el-form-item label="申请人"
              ><el-tag size="small">{{ userName }}</el-tag>
            </el-form-item>
            <el-form-item>
              <el-button
                type="primary"
                size="small"
                style="float: right"
                @click="qjSub"
                >提交申请</el-button
              >
              <el-button
                size="small"
                style="float: right; margin-right: 10px"
                @click="innerVisibleQj = false"
                >取消</el-button
              >
            </el-form-item>
          </el-form>
        </el-dialog>
        <el-dialog width="30%" :visible.sync="innerVisibleLz" append-to-body>
          <el-form :model="formLz">
            <el-form-item label="离职理由">
              <el-input
                type="textarea"
                :rows="6"
                v-model="formLz.filedText"
                style="width: 70%"
              ></el-input>
            </el-form-item>
            <el-form-item label="申请人"
              ><el-tag size="small">{{ userName }}</el-tag>
            </el-form-item>
            <el-form-item>
              <el-button
                type="primary"
                size="small"
                style="float: right"
                @click="LzSub"
                >提交申请</el-button
              >
              <el-button
                size="small"
                style="float: right; margin-right: 10px"
                @click="innerVisibleLz = false"
                >取消</el-button
              >
            </el-form-item>
          </el-form>
        </el-dialog>
        <div><span style="font-weight: bold">申请类型</span></div>
        <div style="margin-top: 10px">
          <el-button
            type="primary"
            plain
            size="small"
            @click="innerVisibleZg = true"
            >转岗申请</el-button
          >
          <el-button
            type="warning"
            plain
            size="small"
            @click="innerVisibleQj = true"
            >请假申请</el-button
          >
          <el-button
            type="danger"
            plain
            size="small"
            @click="innerVisibleLz = true"
            >离职申请</el-button
          >
        </div>
        <div style="margin-top: 20px">
          <span style="font-weight: bold">当前申请列表</span>
        </div>
        <div style="margin-top: 10px">
          <template>
            <el-table style="width: 100%" :data="filedList">
              <el-table-column
                prop="filedTypeName"
                label="申请类型"
              ></el-table-column>
              <el-table-column label="申请状态">
                <template slot-scope="scope">
                  <div slot="reference" class="name-wrapper">
                    <el-tag size="small" v-show="scope.row.filedStatus == 0"
                      >审核中...</el-tag
                    >
                    <el-tag
                      size="small"
                      type="success"
                      v-show="scope.row.filedStatus == 1"
                      >已通过</el-tag
                    >
                    <el-tag
                      size="small"
                      type="danger"
                      v-show="scope.row.filedStatus == 2"
                      >已拒绝</el-tag
                    >
                  </div>
                </template>
              </el-table-column>
            </el-table>
          </template>
        </div>
        <div slot="footer" class="dialog-footer">
          <el-button @click="outerVisible = false" size="small"
            >取 消</el-button
          >
        </div>
      </el-dialog>
    </div>
  </div>
</template>

<script>
export default {
  name: "CommonMana",
  data() {
    return {
      dialog: false,
      outerVisible: false,
      innerVisibleZg: false,
      innerVisibleQj: false,
      innerVisibleLz: false,
      loading: false,
      userEmailAll: [],
      state: "",
      emailTitle: "",
      EmailText: "",
      sendUser: "",
      toUser: "",
      fileList: [],
      fileNameList: [],
      userID: -1,
      userName: "",
      roleList: [],
      formZg: {
        thisRole: "",
        filedTime: "",
        filedText: "",
        filedRole: "",
        roleID: "",
      },
      formQj: {
        filedTime: "",
        filedText: "",
      },
      formLz: {
        filedText: "",
      },
      filedList: [],
    };
  },
  mounted() {
    this.initEmailAll();
    this.initInfo();
    this.initFiledList();
  },
  computed: {
    uploadHeader: function () {
      if (window.sessionStorage.getItem("token")) {
        return {
          Authorization: "Bearer " + window.sessionStorage.getItem("token"),
        };
      } else {
      }
    },
  },
  methods: {
    showDialog() {
      this.dialog = true;
    },
    filedDialog() {
      this.outerVisible = true;
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
      this.state = "";
      this.emailTitle = "";
      this.EmailText = "";
      this.fileList = [];
      this.fileNameList = [];
    },
    AddFiles(response, file, fileList) {
      this.fileNameList.push(file.name);
      console.log(this.fileNameList);
    },
    RemoveFile(file, fileList) {
      this.fileNameList.pop(file.name);
      console.log(this.fileNameList);
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
          files: this.fileNameList,
        };
        this.postRequest("/api/SendEmail/Send", SendEmail).then((resp) => {
          if (resp) {
            this.loading = false;
            this.dialog = false;
            this.state = "";
            this.emailTitle = "";
            this.EmailText = "";
            this.fileList = [];
            this.fileNameList = [];
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
      this.fileList = [];
      this.fileNameList = [];
    },
    initInfo() {
      if (window.sessionStorage.getItem("userInfo")) {
        this.userID = JSON.parse(
          window.sessionStorage.getItem("userInfo")
        ).userID;
        this.userName = JSON.parse(
          window.sessionStorage.getItem("userInfo")
        ).name;
        this.getRequest(
          "/api/UserInfo/GetDetailUserInformation?id=" + this.userID
        ).then((resp) => {
          if (resp) {
            this.formZg.thisRole = resp[0].role.roleName;
          }
        });
      }
      this.getRequest("/api/RoleInfo/GetRoleInformation").then((resp) => {
        if (resp) {
          this.roleList = resp;
        }
      });
    },
    queryRoleAsync(queryString, cb) {
      var restaurants = this.roleList;
      var results = queryString
        ? restaurants.filter(this.queryUserRole(queryString))
        : restaurants;
      cb(results);
    },
    queryUserRole(userName) {
      return (restaurant) => {
        return restaurant.roleName.indexOf(userName) != -1;
      };
    },
    filedSelect(item) {
      this.formZg.roleID = item.roleID;
      this.formZg.filedRole = item.roleName;
    },
    zgSub() {
      let parmams = {
        FiledType: 1,
        FiledTime: this.formZg.filedTime,
        FiledUserID: this.userID,
        FiledToRoleID: this.formZg.roleID,
        FiledTypeName: "转岗申请",
        FiledText: this.formZg.filedText,
      };
      this.postRequest("/api/FiledOperate/FiledOperate", parmams).then(
        (resp) => {
          if (resp) {
            this.innerVisibleZg = false;
            this.formZg = {
              thisRole: "",
              filedTime: "",
              filedText: "",
              filedRole: "",
              roleID: "",
            };
            this.initFiledList();
          }
        }
      );
    },
    qjSub() {
      let parmams = {
        FiledType: 2,
        FiledTypeName: "请假申请",
        FiledText: this.formQj.filedText,
        FiledUserID: this.userID,
      };
      this.postRequest("/api/FiledOperate/FiledOperate", parmams).then(
        (resp) => {
          if (resp) {
            this.innerVisibleQj = false;
            this.formQj = {
              filedTime: "",
              filedText: "",
            };
            this.initFiledList();
          }
        }
      );
    },
    LzSub() {
      let parmams = {
        FiledType: 3,
        FiledTypeName: "离职申请",
        FiledText: this.formQj.filedText,
        FiledUserID: this.userID,
      };
      this.postRequest("/api/FiledOperate/FiledOperate", parmams).then(
        (resp) => {
          if (resp) {
            this.innerVisibleLz = false;
            this.formLz = {
              filedText: "",
            };
            this.initFiledList();
          }
        }
      );
    },
    initFiledList() {
      this.getRequest("/api/FiledOperate/GetFiledList?id=" + this.userID).then(
        (resp) => {
          if (resp) {
            this.filedList = resp;
          }
        }
      );
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
<template>
  <div>
    <div class="userContent">
      <el-card class="user-card" v-for="(user, index) in userlist" :key="index">
        <div slot="header" class="clearfix">
          <span>{{ user.name }}</span>
          <el-button
            style="float: right; padding: 3px 0; color: red"
            type="text"
            icon="el-icon-delete"
            title="删除"
            @click="deleteUser(user.userID)"
          ></el-button>
          <el-popover
            placement="left-start"
            title="岗位变更"
            width="200"
            trigger="click"
            @show="optionsList(user)"
            @hide="updateInfo(user)"
          >
            <div>
              <el-select
                v-model="roles"
                placeholder="请选择"
                size="small"
                @change="UpdateRole"
              >
                <el-option
                  v-for="(all, index) in infoList.roleList"
                  :key="index"
                  :label="all.roleName"
                  :value="all.roleID"
                >
                </el-option>
              </el-select>
            </div>
            <div style="margin-top: 8px">
              <el-select
                v-model="depatrs"
                placeholder="请选择"
                size="small"
                @change="UpdateDepart"
              >
                <el-option
                  v-for="(all, index) in infoList.departmentList"
                  :key="index"
                  :label="all.departmentName"
                  :value="all.departmentID"
                >
                </el-option>
              </el-select>
            </div>
            <el-button
              style="float: right; padding: 3px 0; margin-right: 8px"
              type="text"
              icon="el-icon-setting"
              title="更改"
              slot="reference"
            ></el-button>
          </el-popover>
        </div>
        <div class="imgContent">
          <img
            :src="user.userImg"
            :alt="user.name"
            :title="user.name"
            class="userImg"
          />
        </div>
        <div class="infoContent">
          <div style="margin-top: 8px">
            用户：<el-tag type="info" size="small">{{ user.name }}</el-tag>
          </div>
          <div style="margin-top: 8px">
            职位：<el-tag type="success" size="small">{{
              user.roleName
            }}</el-tag>
          </div>
          <div style="margin-top: 8px">
            部门：<el-tag type="success" size="small">{{
              user.departName
            }}</el-tag>
          </div>
        </div>
      </el-card>
    </div>
  </div>
</template>

<script>
export default {
  name: "PerMv",
  data() {
    return {
      userlist: [],
      infoList: [],
      roles: "",
      depatrs: "",
      roleid: -1,
      departid: -1,
    };
  },
  mounted() {
    this.initUserList();
  },
  methods: {
    optionsList(user) {
      this.getInfoList();
      this.roles = user.roleName;
      this.depatrs = user.departName;
    },
    initUserList() {
      let id = window.sessionStorage.getItem("userid");
      this.getRequest("/api/UserInfo/GetOtherUser?id=" + id).then((resp) => {
        if (resp) {
          this.userlist = resp;
        }
      });
    },
    getInfoList() {
      this.getRequest("/api/UserInfo/GetRoleDepartList").then((resp) => {
        if (resp) {
          this.infoList = resp;
        }
      });
    },
    deleteUser(id) {
      this.$confirm("确认删除改项?", "提示", {
        confirmButtonText: "确定",
        cancelButtonText: "取消",
        type: "warning",
      })
        .then(() => {
          this.deleteRequest("/api/UserInfo/DelUser/?UserID=" + id).then(
            (resp) => {
              if (resp) {
                this.initUserList();
              }
            }
          );
        })
        .catch(() => {
          this.$message({
            type: "info",
            message: "已取消",
          });
        });
    },
    UpdateRole(item) {
      this.roleid = item;
    },
    UpdateDepart(item) {
      this.departid = item;
    },
    updateInfo(user) {
      let objA = {
        UserID: user.userID,
        RoleID: this.roleid,
      };
      let objB = {
        UserID: user.userID,
        DepartmentID: this.departid,
      };
      this.putRequest("/api/UserInfo/UpdateUserRole", objA);
      this.putRequest("/api/UserInfo/UpdateUserDepart", objB).then((resp) => {
        if (resp) {
          this.initUserList();
        }
      });
    },
  },
};
</script>
<style scoped>
.user-card {
  width: 350px;
  margin-bottom: 20px;
}
.userContent {
  display: flex;
  justify-content: space-around;
  flex-wrap: wrap;
  margin-top: 30px;
}
.userImg {
  width: 75px;
  height: 75px;
  border-radius: 75px;
}
.imgContent {
  width: 100%;
  display: flex;
  justify-content: center;
}
.infoContent {
  color: rgb(132, 160, 252);
  margin-top: 15px;
  padding-left: 15px;
}
</style>
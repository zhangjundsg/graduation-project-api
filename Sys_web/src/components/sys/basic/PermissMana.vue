<template>
  <div style="width: 100%">
    <div class="mainMenuPer">
      <el-collapse v-model="activeName" accordion @change="change">
        <el-collapse-item
          :title="r.roleName"
          :name="r.roleID"
          v-for="(r, index) in roles"
        >
          <el-card class="box-card">
            <div slot="header" class="clearfix">
              <span>可访问菜单</span>
            </div>
            <div>
              <el-tree
                :data="allMenu"
                :props="defaultProps"
                show-checkbox
                ref="tree"
                :default-checked-keys="selectMenus"
                node-key="menuID"
              ></el-tree>
              <div style="display: flex; justify-content: flex-end">
                <el-button size="mini" @click="cancelUpdate">取消</el-button>
                <el-button
                  size="mini"
                  type="primary"
                  @click="updatePermiss(r.roleID, index)"
                  >确认</el-button
                >
              </div>
            </div>
          </el-card>
        </el-collapse-item>
      </el-collapse>
    </div>
  </div>
</template>

<script>
export default {
  name: "PermissMana",
  data() {
    return {
      roles: [],
      allMenu: [],
      defaultProps: {
        children: "children",
        label: "menuName",
      },
      selectMenus: [],
      activeName: -1,
    };
  },
  mounted() {
    this.initRoles();
  },
  methods: {
    cancelUpdate() {
      this.activeName = -1;
    },
    updatePermiss(rid, index) {
      let tree = this.$refs.tree[index].getCheckedNodes(false, true);
      let ckMenuID = [];
      Object.keys(tree).forEach((item) => {
        ckMenuID.push(tree[item].menuID);
      });
      let params = {
        roleID: rid,
        menuID: ckMenuID,
      };
      this.postRequest("/api/Menu/UpdateMenu", params).then((resp) => {
        if (resp) {
          this.initRoles();
          this.activeName = -1;
        }
      });
    },
    change(id) {
      if (id) {
        this.selectMenus = [];
        this.initMenus();
        this.initSelectMenus(id);
      }
    },
    initSelectMenus(roleid) {
      this.getRequest("/api/Menu/GetMenuArray/?roleID=" + roleid).then(
        (resp) => {
          if (resp) {
            this.selectMenus = resp;
          }
        }
      );
    },
    initMenus() {
      this.getRequest("/api/Menu/GetAllMenuList").then((resp) => {
        if (resp) {
          this.allMenu = resp;
        }
      });
    },
    initRoles() {
      this.getRequest("/api/RoleInfo/GetRoleInformation").then((resp) => {
        if (resp) {
          this.roles = resp;
        }
      });
    },
  },
};
</script>
<style>
.mainMenuPer {
  width: 55%;
}
</style>
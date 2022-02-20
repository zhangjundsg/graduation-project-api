<template>
  <div>
    <el-container>
      <el-header class="homeHeader">人员办公管理系统</el-header>
      <el-container>
        <el-aside width="200px">
          <el-menu router unique-opened>
            <el-submenu
              :index="index + ''"
              v-for="(item, index) in routes"
              :key="index"
              v-if="!item.hidden"
            >
              <template slot="title">
                <i :class="item.iconCls" style="margin-right: 10px"></i>
                <span>{{ item.name }}</span>
              </template>
              <el-menu-item
                :index="children.path"
                v-for="(children, indexCd) in item.children"
              >
                {{ children.name }}
              </el-menu-item>
            </el-submenu>
          </el-menu>
        </el-aside>
        <el-main>
          <router-view />
        </el-main>
      </el-container>
    </el-container>
  </div>
</template>

<script>
export default {
  name: "Home",
  computed: {
    routes() {
      return this.$store.state.routes;
    },
  },
};
</script>

<style>
.homeHeader {
  background-color: #409eff;
  display: flex;
  align-items: center;
  justify-content: space-between;
  padding: 0 15px;
  box-sizing: border-box;
  font-size: 25px;
  color: white;
  font-family: 华文楷体;
}
</style>
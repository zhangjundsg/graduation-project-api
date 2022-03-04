<template>
  <div>
    <el-tabs v-model="activeName" type="card">
      <el-tab-pane label="部门管理" name="DepMana">部门管理</el-tab-pane>
      <el-tab-pane label="职位管理" name="PosMana">职位管理</el-tab-pane>
      <el-tab-pane label="权限组" name="PermissMana">角色管理</el-tab-pane>
    </el-tabs>
  </div>
</template>

<script>
import DepMana from "../../components/sys/basic/DepMana";
import PosMana from "../../components/sys/basic/PosMana";
import PermissMana from "../../components/sys/basic/PermissMana";

export default {
  name: "SysBasic",
  data() {
    return {
      activeName: "DepMana",
    };
  },
  components: {
    DepMana,
    PosMana,
    PermissMana,
  },
};
</script>

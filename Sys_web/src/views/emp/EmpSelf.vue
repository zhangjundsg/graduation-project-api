<template>
  <div>
    <el-tabs v-model="activeName" type="card">
      <el-tab-pane label="详细资料" name="selfMana"
        ><SelfMana></SelfMana
      ></el-tab-pane>
      <el-tab-pane label="常用功能" name="commonMana"
        ><CommonMana></CommonMana
      ></el-tab-pane>
      <el-tab-pane label="修改信息" name="infoMana"
        ><InfoMana></InfoMana
      ></el-tab-pane>
    </el-tabs>
  </div>
</template>

<script>
import CommonMana from "../../components/emp/self/CommonMana";
import InfoMana from "../../components/emp/self/InfoMana";
import SelfMana from "../../components/emp/self/SelfMana";

export default {
  name: "EmpSelf",
  data() {
    return {
      activeName: "selfMana",
    };
  },
  components: {
    CommonMana,
    InfoMana,
    SelfMana,
  },
};
</script>
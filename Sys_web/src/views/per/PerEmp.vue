<template>
  <div>
    <div>
      <el-input
        placeholder="请输入内容"
        v-model="searchPer"
        clearable
        size="small"
        style="width: 60%"
      >
        <i slot="prefix" class="el-input__icon el-icon-search"></i>
      </el-input>
      <el-button type="primary" plain size="small" style="margin-left: 15px"
        >搜索</el-button
      >
    </div>
    <div style="margin-top: 20px; width: 70%">
      <div>
        <template>
          <el-table border size="small">
            <el-table-column type="selection" width="40"> </el-table-column>
            <el-table-column prop="userID" label="编号" width="80">
            </el-table-column>
            <el-table-column prop="name" label="姓名" width="180">
            </el-table-column>
            <el-table-column prop="email" label="联系地址"> </el-table-column>
            <el-table-column prop="roleName" label="当前职位">
            </el-table-column>
            <el-table-column prop="departmentName" label="所在部门">
            </el-table-column>
          </el-table>
        </template>
      </div>
      <div style="margin-top: 10px; float: right">
        <el-pagination
          :page-sizes="[10, 20, 30, 40]"
          :page-size="10"
          layout="total, sizes, prev, pager, next, jumper"
          :total="100"
          :hide-on-single-page="isOneShow"
        >
        </el-pagination>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "PerEmp",
  data() {
    return {
      isOneShow: true,
      searchPer: "",
    };
  },
};
</script>
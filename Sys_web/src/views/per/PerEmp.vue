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
          <el-table border size="small" :data="userInformation" stripe>
            <el-table-column type="selection" width="40"> </el-table-column>
            <el-table-column prop="userID" label="编号" width="80">
            </el-table-column>
            <el-table-column prop="name" label="姓名" width="120">
            </el-table-column>
            <el-table-column prop="email" label="联系地址" width="200">
            </el-table-column>
            <el-table-column prop="roleName" label="当前职位">
            </el-table-column>
            <el-table-column prop="departmentName" label="所在部门">
            </el-table-column>
            <el-table-column prop="registerTime" label="入职时间" width="180">
            </el-table-column>
          </el-table>
        </template>
      </div>
      <div style="margin-top: 10px; float: right">
        <el-pagination
          :current-page="pageIndex"
          :page-sizes="[5, 10, 15, 20]"
          :page-size="pageSize"
          layout="total, sizes, prev, pager, next, jumper"
          :total="PageCount"
          @current-change="toPage"
          @size-change="pageSizeHandel"
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
      searchPer: "",
      userInformation: [],
      pageIndex: 1,
      pageSize: 5,
      PageCount: 0,
    };
  },
  mounted() {
    this.getUserInfo();
  },
  methods: {
    pageSizeHandel(size) {
      this.pageSize = size;
      this.pageIndex = 1;
      this.getUserInfo();
    },
    toPage(Index) {
      this.pageIndex = Index;
      this.getUserInfo();
    },
    getUserInfo() {
      this.getRequest(
        "/api/UserInfo/GetAllUserInformation/?pageIndex=" +
          this.pageIndex +
          "&pageSize=" +
          this.pageSize
      ).then((resp) => {
        if (resp) {
          this.userInformation = resp.list;
          this.PageCount = resp.pageCount;
        }
      });
    },
  },
};
</script>
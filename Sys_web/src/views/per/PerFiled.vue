<template>
  <div>
    <div></div>
    <div style="margin-top: 25px">
      <div style="display: inline-block">
        <el-badge :value="zgCount" class="item">
          <el-avatar>转岗申请</el-avatar>
        </el-badge>
      </div>
      <div style="display: inline-block; margin-left: 45px">
        <el-badge :value="qjCount" class="item">
          <el-avatar>请假申请</el-avatar>
        </el-badge>
      </div>
      <div style="display: inline-block; margin-left: 45px">
        <el-badge :value="lzCount" class="item">
          <el-avatar>离职申请</el-avatar>
        </el-badge>
      </div>
    </div>
    <div style="margin-top: 25px">
      <el-table border size="small" :data="filedList" stripe>
        <el-table-column prop="filedID" label="申请编号" width="80">
        </el-table-column>
        <el-table-column prop="filedUser" label="申请人" width="100">
        </el-table-column>
        <el-table-column prop="filedTypeName" label="申请类型" width="150">
        </el-table-column>
        <el-table-column prop="filedText" label="申请理由" width="500">
        </el-table-column>
        <el-table-column label="申请状态" width="100">
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
        <el-table-column label="操作">
          <template slot-scope="scope">
            <el-button size="mini" @click="agree(scope.$index, scope.row)"
              >同意</el-button
            >
            <el-button
              size="mini"
              type="danger"
              @click="refuse(scope.$index, scope.row)"
              >拒绝</el-button
            >
          </template>
        </el-table-column>
      </el-table>
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
</template>

<script>
export default {
  name: "PerFiled",
  data() {
    return {
      filedList: [],
      pageIndex: 1,
      pageSize: 5,
      PageCount: 0,
      zgCount: 0,
      qjCount: 0,
      lzCount: 0,
    };
  },
  mounted() {
    this.initFiledList();
    this.initstats();
  },
  methods: {
    agree(index, data) {
      let parmams = {
        FiledID: data.filedID,
        FiledStatus: 1,
        FiledType: this.filedList[index].filedType,
        FiledUserID: this.filedList[index].filedUserID,
        FiledTypeName: data.filedTypeName,
        FiledText: data.filedText,
        FiledToRoleID: this.filedList[index].filedToRoleID,
      };
      this.putRequest("/api/FiledOperate/UpdateFiledStats", parmams).then(
        (resp) => {
          if (resp) {
            this.initFiledList();
            this.initstats();
          }
        }
      );
      if (this.filedList[index].filedType == 1) {
        let data = {
          UserID: this.filedList[index].filedUserID,
          RoleID: this.filedList[index].filedToRoleID,
        };
        this.putRequest("/api/UserInfo/UpdateUserRole", data);
      }
    },
    refuse(index, data) {
      let parmams = {
        FiledID: data.filedID,
        FiledStatus: 2,
        FiledType: this.filedList[index].filedType,
        FiledUserID: this.filedList[index].filedUserID,
        FiledTypeName: data.filedTypeName,
        FiledText: data.filedText,
        FiledToRoleID: this.filedList[index].filedToRoleID,
      };
      this.putRequest("/api/FiledOperate/UpdateFiledStats", parmams).then(
        (resp) => {
          if (resp) {
            this.initFiledList();
            this.initstats();
          }
        }
      );
    },
    initFiledList() {
      this.getRequest(
        "/api/FiledOperate/GetFiledListAll?index=" +
          this.pageIndex +
          "&pageSize=" +
          this.pageSize
      ).then((resp) => {
        if (resp) {
          this.filedList = resp.fileList;
          this.PageCount = resp.totalPage;
        }
      });
    },
    toPage(Index) {
      this.pageIndex = Index;
      this.initFiledList();
    },
    pageSizeHandel(size) {
      this.pageSize = size;
      this.pageIndex = 1;
      this.initFiledList();
    },
    initstats() {
      this.getRequest("/api/FiledOperate/GetFiledStats").then((resp) => {
        if (resp) {
          this.zgCount = resp.zgCount;
          this.qjCount = resp.qjCount;
          this.lzCount = resp.lzCount;
        }
      });
    },
  },
};
</script>
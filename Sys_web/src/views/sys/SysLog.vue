<template>
  <div>
    <div style="width: 100%; margin-top: 30px">
      <el-table :data="logList" style="width: 100%">
        <el-table-column
          fixed
          prop="logDateTime"
          label="发生时间"
          style="width: 10%"
        >
        </el-table-column>
        <el-table-column prop="logType" label="日志类型" style="width: 5%">
        </el-table-column>
        <el-table-column prop="application" label="项目" style="width: 5%">
        </el-table-column>
        <el-table-column prop="action" label="具体位置" style="width: 10%">
        </el-table-column>
        <el-table-column
          prop="operatingaddress"
          label="错误来源"
          style="width: 20%"
        >
        </el-table-column>
        <el-table-column prop="logContext" label="日志信息" style="width: 30%">
        </el-table-column>
        <el-table-column prop="exception" label="详细" style="width: 20%">
        </el-table-column>
      </el-table>
    </div>
    <div style="margin-top: 10px; float: right">
      <el-pagination
        :current-page="pageIndex"
        :page-sizes="[10, 15, 20, 25]"
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
  name: "SysLog",
  data() {
    return {
      logList: [],
      pageIndex: 1,
      pageSize: 10,
      PageCount: -1,
    };
  },
  mounted() {
    this.initLogList();
  },
  methods: {
    initLogList() {
      this.getRequest(
        "/api/Log/GetLogList/?PageIndex=" +
          this.pageIndex +
          "&PageSize=" +
          this.pageSize
      ).then((resp) => {
        if (resp) {
          this.logList = resp.list;
          this.PageCount = resp.count;
        }
      });
    },
    toPage(Index) {
      this.pageIndex = Index;
      this.initLogList();
    },
    pageSizeHandel(size) {
      this.pageSize = size;
      this.pageIndex = 1;
      this.initLogList();
    },
  },
};
</script>
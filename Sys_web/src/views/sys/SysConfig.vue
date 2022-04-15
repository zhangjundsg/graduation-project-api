<template>
  <div>
    <div style="margin-top: 20px">
      <span style="font-size: 28px; font-weight: blod">基础设置</span>
    </div>
    <div style="margin-top: 50px; width: 45%">
      <el-card class="box-card">
        <div slot="header" class="clearfix">
          <span>文件上传设置</span>
          <div style="margin-top: 20px">
            <el-tag size="small">是否允许上传文件：</el-tag>
            <el-switch
              style="display: inline-block; margin-left: 10px"
              v-model="isUpdate"
              active-color="#13ce66"
              inactive-color="#ff4949"
              active-text="是"
              inactive-text="否"
              size="small"
              @change="changeHandle"
            >
            </el-switch>
          </div>
          <div v-show="isUpdate == true">
            <div style="margin-top: 10px">
              <el-tag size="small">上传文件最大限制：</el-tag>
              <el-input
                placeholder="输入最大限制"
                v-model="updateFileSize"
                clearable
                size="small"
                style="width: 120px; margin-left: 10px"
              >
              </el-input
              >(MB)
            </div>
            <div style="margin-top: 10px">
              <el-tooltip
                class="item"
                effect="dark"
                content="多个类型间用|隔开"
                placement="top"
              >
                <el-tag size="small">允许上传文件类型：</el-tag>
              </el-tooltip>
              <el-input
                placeholder="输入最大限制"
                v-model="updateFileType"
                clearable
                size="small"
                style="margin-top: 8px"
              >
              </el-input>
              <div style="margin-top: 22px; float: right">
                <el-button
                  type="success"
                  round
                  size="small"
                  @click="UpdateFileOptions"
                  >确认修改</el-button
                >
              </div>
            </div>
          </div>
        </div>
      </el-card>
    </div>
  </div>
</template>

<script>
export default {
  name: "SysConfig",
  data() {
    return {
      isUpdate: false,
      updateFileSize: -1,
      updateFileType: "",
    };
  },
  mounted() {
    this.initOptions();
  },
  methods: {
    initOptions() {
      this.getRequest("/api/Options/GetSysOptions").then((resp) => {
        if (resp) {
          resp.forEach((item) => {
            if (item.optionName == "IsFileUPdaload") {
              this.isUpdate = item.enabled;
            }
            if (item.optionName == "FileSize") {
              this.updateFileSize = item.parmars / 1024 / 1024;
            }
            if (item.optionName == "FileType") {
              this.updateFileType = item.parmars;
            }
          });
        }
      });
    },
    changeHandle(status) {
      this.isUpdate = status;
      let parmars = {
        OptionName: "IsFileUPdaload",
        Enabled: status,
        Parmars: "",
      };
      this.putRequest("/api/Options/UpdateSysOptions", parmars).then(
        (resp) => {}
      );
    },
    UpdateFileOptions() {
      let fileSize = {
        OptionName: "FileSize",
        Enabled: this.isUpdate,
        Parmars: this.updateFileSize * 1024 * 1024 + "",
      };
      let fileType = {
        OptionName: "FileType",
        Enabled: this.isUpdate,
        Parmars: this.updateFileType,
      };
      this.putRequest("/api/Options/UpdateSysOptions", fileSize).then(
        (resp) => {}
      );
      this.putRequest("/api/Options/UpdateSysOptions", fileType).then(
        (resp) => {
          this.$message({
            type: "success",
            message: "已更改",
          });
        }
      );
    },
  },
};
</script>
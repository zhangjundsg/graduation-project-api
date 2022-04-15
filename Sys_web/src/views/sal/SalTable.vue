<template>
  <div>
    <div style="margin-top: 30px">
      <el-table :data="salaryData" border stripe>
        <el-table-column prop="id" label="编号" width="50"> </el-table-column>
        <el-table-column prop="name" label="账套名称" width="120">
        </el-table-column>
        <el-table-column prop="basicSalary" label="基本工资" width="90">
        </el-table-column>
        <el-table-column prop="trafficSalary" label="交通补助" width="90">
        </el-table-column>
        <el-table-column prop="trafficSalary" label="午餐补助" width="90">
        </el-table-column>
        <el-table-column prop="bonus" label="奖金" width="65">
        </el-table-column>
        <el-table-column label="养老金" align="center">
          <el-table-column prop="pensionBase" label="养老金基数" width="100">
          </el-table-column>
          <el-table-column prop="pensionPer" label="比率" width="70">
          </el-table-column>
        </el-table-column>
        <el-table-column label="医疗保险" align="center">
          <el-table-column prop="medicalBase" label="医保基数" width="100">
          </el-table-column>
          <el-table-column prop="medicalPer" label="比率" width="70">
          </el-table-column>
        </el-table-column>
        <el-table-column label="公积金" align="center">
          <el-table-column
            prop="accumulationFundBase"
            label="公积金基数"
            width="100"
          >
          </el-table-column>
          <el-table-column prop="accumulationFundPer" label="比率" width="70">
          </el-table-column>
        </el-table-column>
        <el-table-column prop="createDate" label="启用时间" width="180">
        </el-table-column>
        <el-table-column label="操作">
          <template slot-scope="scope">
            <el-button
              size="mini"
              @click="showDilogEdit(scope.$index, scope.row)"
              >编辑</el-button
            >
          </template>
        </el-table-column>
      </el-table>
    </div>
    <el-dialog
      title="工资账套"
      :visible.sync="dialogVisible"
      width="35%"
      :before-close="handleClose"
    >
      <div>
        <el-form :model="form" label-width="120px" :rules="rules" ref="form">
          <el-form-item label="账套名称" prop="name">
            <el-input
              v-model="form.name"
              size="small"
              style="width: 300px"
            ></el-input>
          </el-form-item>
          <el-form-item label="基本工资" prop="basicSalary">
            <el-input
              v-model="form.basicSalary"
              size="small"
              style="width: 300px"
            ></el-input>
          </el-form-item>
          <el-form-item label="奖金" prop="bonus">
            <el-input
              v-model="form.bonus"
              size="small"
              style="width: 300px"
            ></el-input>
          </el-form-item>
          <el-form-item label="交通补助" prop="trafficSalary">
            <el-input
              v-model="form.trafficSalary"
              size="small"
              style="width: 300px"
            ></el-input>
          </el-form-item>
          <el-form-item label="午餐补助" prop="lunchSalary">
            <el-input
              v-model="form.lunchSalary"
              size="small"
              style="width: 300px"
            ></el-input>
          </el-form-item>
          <el-form-item label="养老金基数" prop="pensionBase">
            <el-input
              v-model="form.pensionBase"
              size="small"
              style="width: 300px"
            ></el-input>
          </el-form-item>
          <el-form-item label="比例" prop="pensionPer">
            <el-input
              v-model="form.pensionPer"
              size="small"
              style="width: 300px"
            ></el-input>
          </el-form-item>
          <el-form-item label="医保基数" prop="medicalBase">
            <el-input
              v-model="form.medicalBase"
              size="small"
              style="width: 300px"
            ></el-input>
          </el-form-item>
          <el-form-item label="比例" prop="medicalPer">
            <el-input
              v-model="form.medicalPer"
              size="small"
              style="width: 300px"
            ></el-input>
          </el-form-item>
          <el-form-item label="公积金基数" prop="accumulationFundBase">
            <el-input
              v-model="form.accumulationFundBase"
              size="small"
              style="width: 300px"
            ></el-input>
          </el-form-item>
          <el-form-item label="比例" prop="accumulationFundPer">
            <el-input
              v-model="form.accumulationFundPer"
              size="small"
              style="width: 300px"
            ></el-input>
          </el-form-item>
        </el-form>
      </div>
      <span slot="footer" class="dialog-footer">
        <el-button @click="dialogVisible = false" size="small">取 消</el-button>
        <el-button type="primary" @click="UpdateSalary" size="small"
          >确 定</el-button
        >
      </span>
    </el-dialog>
  </div>
</template>

<script>
export default {
  name: "SalTable",
  data() {
    return {
      salaryData: [],
      dialogVisible: false,
      form: {
        id: 0,
        createDate: "",
        accumulationFundBase: "",
        accumulationFundPer: "",
        basicSalary: "",
        bonus: "",
        lunchSalary: "",
        medicalBase: "",
        medicalPer: "",
        name: "",
        pensionBase: "",
        pensionPer: "",
        trafficSalary: "",
      },
      rules: {
        name: [{ required: true, message: "此项不能为空！", trigger: "blur" }],
        basicSalary: [
          { required: true, message: "此项不能为空！", trigger: "blur" },
        ],
        bonus: [{ required: true, message: "此项不能为空！", trigger: "blur" }],
        trafficSalary: [
          { required: true, message: "此项不能为空！", trigger: "blur" },
        ],
        lunchSalary: [
          { required: true, message: "此项不能为空！", trigger: "blur" },
        ],
        pensionBase: [
          { required: true, message: "此项不能为空！", trigger: "blur" },
        ],
        medicalBase: [
          { required: true, message: "此项不能为空！", trigger: "blur" },
        ],
        medicalPer: [
          { required: true, message: "此项不能为空！", trigger: "blur" },
        ],
        pensionPer: [
          { required: true, message: "此项不能为空！", trigger: "blur" },
        ],
        accumulationFundBase: [
          { required: true, message: "此项不能为空！", trigger: "blur" },
        ],
        accumulationFundPer: [
          { required: true, message: "此项不能为空！", trigger: "blur" },
        ],
      },
    };
  },
  mounted() {
    this.initSalaryData();
  },
  methods: {
    initSalaryData() {
      this.getRequest("/api/Salary/GetSalaryData").then((resp) => {
        if (resp) {
          this.salaryData = resp;
        }
      });
    },
    showDilogEdit(index, data) {
      Object.assign(this.form, data);
      this.dialogVisible = true;
    },
    UpdateSalary() {
      this.$refs.form.validate((valid) => {
        if (valid) {
          this.putRequest("/api/Salary/UpdateSalary", this.form).then(
            (resp) => {
              this.dialogVisible = false;
              this.initSalaryData();
            }
          );
        } else {
          this.$message({
            showClose: true,
            message: "请输入所有字段",
            type: "error",
          });
          return false;
        }
      });
    },
    handleClose(done) {
      done();
    },
  },
};
</script>
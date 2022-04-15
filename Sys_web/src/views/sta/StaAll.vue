<template>
  <div>
    <div>
      <div
        id="main"
        style="
          width: 600px;
          height: 500px;
          margin-top: 40px;
          display: inline-block;
        "
      ></div>
      <div
        id="main2"
        style="
          width: 600px;
          height: 500px;
          margin-top: 40px;
          display: inline-block;
        "
      ></div>
    </div>
  </div>
</template>

<script>
export default {
  name: "StaAll",
  data() {
    return {
      echartsData: {},
      statsDate: {
        dimission: 0,
        newUserAdd: 0,
        notAudited: 0,
        passed: 0,
        rejected: 0,
      },
    };
  },
  mounted() {
    this.initFiledData();
  },
  methods: {
    initEcharts() {
      var myChart = this.echarts.init(document.getElementById("main"));

      var option = {
        title: {
          text: "系统申请统计",
          left: "center",
        },
        tooltip: {
          trigger: "item",
        },
        legend: {
          orient: "vertical",
          left: "left",
        },
        series: [
          {
            name: "系统申请",
            type: "pie",
            radius: "50%",
            data: [
              {
                value: this.statsDate.passed,
                name: "已通过",
                itemStyle: { color: "#98FB98" },
              },
              {
                value: this.statsDate.rejected,
                name: "已拒绝",
                itemStyle: { color: "#DC143C" },
              },
              {
                value: this.statsDate.notAudited,
                name: "未审核",
                itemStyle: { color: "#AFEEEE" },
              },
            ],
            emphasis: {
              itemStyle: {
                shadowBlur: 10,
                shadowOffsetX: 0,
                shadowColor: "rgba(0, 0, 0, 0.5)",
              },
            },
          },
        ],
      };
      myChart.setOption(option);
    },
    initEchartsTwo() {
      var myChart = this.echarts.init(document.getElementById("main2"));

      var option = {
        title: {
          text: "近期人事变动",
          subtext: "近1个月",
          left: "center",
        },
        tooltip: {},
        legend: {
          show: true,
          data: ["入职员工", "离职员工"],
        },
        xAxis: {
          type: "category",
          data: ["加入员工", "离职员工"],
        },
        yAxis: {
          type: "value",
          interval: 1,
        },
        series: [
          {
            type: "bar",
            data: [
              {
                name: "入职",
                value: this.statsDate.newUserAdd,
                itemStyle: {
                  color: "#98FB98",
                },
              },
              {
                name: "离职",
                value: this.statsDate.dimission,
                itemStyle: {
                  color: "#DC143C",
                },
              },
            ],
          },
        ],
      };
      myChart.setOption(option);
    },
    initFiledData() {
      this.getRequest("/api/StatsData/StatsData").then((resp) => {
        if (resp) {
          this.statsDate = resp;
          this.initEcharts();
          this.initEchartsTwo();
        }
      });
    },
  },
};
</script>
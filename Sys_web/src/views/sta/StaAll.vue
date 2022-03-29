<template>
  <div>
    <div>
      <div id="main" style="width: 600px; height: 400px"></div>
    </div>
  </div>
</template>

<script>
export default {
  name: "StaAll",
  data() {
    return {
      echartsData: {},
    };
  },
  mounted() {
    this.initEcharts();
  },
  methods: {
    initEcharts() {
      var myChart = this.echarts.init(document.getElementById("main"));

      var option = {
        title: {
          text: "ECharts",
        },
        tooltip: {},
        legend: {},
        xAxis: {
          data: ["衬衫", "羊毛衫", "雪纺衫", "裤子", "高跟鞋", "袜子"],
        },
        yAxis: {},
        series: [
          {
            name: "销量",
            type: "bar",
            data: [5, 20, 36, 10, 10, 20],
          },
        ],
      };
      myChart.setOption(option);
    },
  },
};
</script>
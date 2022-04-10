import Vue from 'vue'
import ElementUI, { TabPane } from 'element-ui'
import 'element-ui/lib/theme-chalk/index.css'
import 'font-awesome/css/font-awesome.css'
import * as echarts from 'echarts'

import store from './store'
import App from './App.vue'
import router from './router'

import { postRequest } from './utils/api'
import { putRequest } from './utils/api'
import { getRequest } from './utils/api'
import { deleteRequest } from './utils/api'
import { initMenu } from './utils/menu'
import { downloadRequest } from './utils/downfile'

Vue.config.productionTip = false
Vue.use(ElementUI);
//插件形式使用
Vue.prototype.postRequest = postRequest;
Vue.prototype.putRequest = putRequest;
Vue.prototype.getRequest = getRequest;
Vue.prototype.deleteRequest = deleteRequest;
Vue.prototype.downloadRequest = downloadRequest;
Vue.prototype.echarts = echarts;

router.beforeEach((to, from, next) => {
  if (window.sessionStorage.getItem('token')) {
    initMenu(router, store);
    if (!window.sessionStorage.getItem('userInfo')) {
      const userid = window.sessionStorage.getItem('userid');
      return getRequest('/api/UserInfo/GetUserInformation/?id=' + userid).then(resp => {
        window.sessionStorage.setItem('userInfo', JSON.stringify(resp));
        next();
      })
    }
    next();
  } else {
    if (to.path == '/') {
      next();
    } else {
      next('/?redirect=' + to.path);
    }
  }
})

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')

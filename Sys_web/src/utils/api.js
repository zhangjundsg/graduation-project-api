import axios from 'axios';
import { Message } from 'element-ui';
import router from '../router';

//请求拦截器
axios.interceptors.request.use(config => {
    if (window.sessionStorage.getItem('token')) {
        config.headers['Authorization'] = `Bearer ${window.sessionStorage.getItem('token')}`;
    }
    return config;

}, error => {
    console.log(error);
})

//响应拦截器
axios.interceptors.response.use(success => {
    if (success.status && success.status == 200) {
        if (success.data.code == 500 || success.data.code == 401 || success.data.code == 403 || success.data.code == 233 || success.data.code == 255) {
            Message.error({ message: success.data.msg });
            return;
        }
        if (success.data.msg) {
            Message.success({ message: success.data.msg });
        }
    }
    return success.data;

}, error => {
    if (error.response.code == 504 || error.response.code == 404) {
        Message.error({ message: '服务器错误！' });
    } else if (error.response.code == 403) {
        Message.error({ message: '权限不足！' });
    } else if (error.response.code == 401) {
        Message.error({ message: '未登录！' });
        router.replace('/');
    } else if (error.response.code == 400) {
        Message.error({ message: '请求参数错误！' });
    } else {
        if (error.response.data.msg) {
            Message.error({ message: error.response.data.msg });
        }
    }
    return;
});


//post请求
let base = '';
export const postRequest = (url, params) => {
    return axios({
        method: 'post',
        url: `${base}${url}`,
        data: params
    })
}

//put请求
export const putRequest = (url, params) => {
    return axios({
        method: 'put',
        url: `${base}${url}`,
        data: params,
    })
}

//get请求
export const getRequest = (url, params) => {
    return axios({
        method: 'get',
        url: `${base}${url}`,
        data: params
    })
}

//delete请求
export const deleteRequest = (url, params) => {
    return axios({
        method: 'delete',
        url: `${base}${url}`,
        data: params
    })
}
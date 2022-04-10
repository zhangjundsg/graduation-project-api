import axios from 'axios';

export const service = axios.create({
    responseType: 'arraybuffer'
})

service.interceptors.request.use(config => {
    config.headers['Authorization'] = `Bearer ${window.sessionStorage.getItem('token')}`;
    return config;

}, error => {
    console.log(error);
})

service.interceptors.response.use(resp => {
    const headers = resp.headers;
    let reg = RegExp(/application\/json/);
    if (headers['content-type'].match(reg)) {
        resp.data = unitToString(resp.data);
    } else {
        let fileDownload = require('js-file-download');
        let filename = '员工数据.xlsx';
        let contentType = headers['content-type'];
        fileDownload(resp.data, filename, contentType);
    }
}, error => {
    console.log(error);
})

function unitToString(unitArray) {
    let encodedString = String.fromCharCode.apply(null, new Uint8Array(unitArray));
    let decodeString = decodeURIComponent(escape(encodedString));
    return JSON.parse(decodeString);
}

let base = '';
export const downloadRequest = (url, params) => {
    return service({
        method: 'get',
        url: `${base}${url}`,
        data: params
    })
}

export default service;
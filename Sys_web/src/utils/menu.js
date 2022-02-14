import { getRequest } from "./api";



export const initMenu = (router, store) => {
    if (store.state.routes.length > 0) {
        return;
    }

    getRequest('/api/Menu').then(data => {
        //格式化路由
        let Routes = formatRoutes(data);
        //添加路由
        router.addRoutes(Routes);
        //将数据加入vuex
        store.commit('initRoutes', Routes);
    })

}

export const formatRoutes = (routes) => {
    let fmtRoutes = [];
    routes.forEach(router => {
        let {
            menuPath,
            component,
            menuName,
            iconCls,
            children,
        } = router;
        if (children && children instanceof Array) {
            children = formatRoutes(children);
        }
        let fmRouter = {
            path: menuPath,
            name: menuName,
            iconCls: iconCls,
            children: children,
            component(resolve) {
                if (component.startsWith('Home')) {
                    require(['../views/' + component + '.vue'], resolve)
                } else if (component.startsWith('Emp')) {
                    require(['../views/emp/' + component + '.vue'], resolve)
                } else if (component.startsWith('Per')) {
                    require(['../views/per/' + component + '.vue'], resolve)
                } else if (component.startsWith('Sal')) {
                    require(['../views/sal/' + component + '.vue'], resolve)
                } else if (component.startsWith('Sta')) {
                    require(['../views/sta/' + component + '.vue'], resolve)
                } else if (component.startsWith('Sys')) {
                    require(['../views/sys/' + component + '.vue'], resolve)
                }
            }
        }
        fmtRoutes.push(fmRouter);
    });
    return fmtRoutes;
}
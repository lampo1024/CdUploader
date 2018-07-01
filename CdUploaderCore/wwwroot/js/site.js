$(function () {
    jconfirm.defaults = {
        title: '提示信息',
        titleClass: '',
        type: 'default',
        typeAnimated: true,
        draggable: true,
        dragWindowGap: 15,
        dragWindowBorder: true,
        animateFromElement: true,
        smoothContent: true,
        content: 'Are you sure to continue?',
        buttons: {},
        defaultButtons: {
            ok: {
                text: "确 实",
                action: function () {
                }
            },
            close: {
                text: "取 消",
                action: function () {
                }
            }
        },
        contentLoaded: function (data, status, xhr) {
        },
        icon: '',
        lazyOpen: false,
        bgOpacity: null,
        theme: 'light',
        animation: 'scale',
        closeAnimation: 'scale',
        animationSpeed: 400,
        animationBounce: 1,
        rtl: false,
        container: 'body',
        containerFluid: false,
        backgroundDismiss: true,
        backgroundDismissAnimation: 'shake',
        autoClose: false,
        closeIcon: null,
        closeIconClass: false
    };
});
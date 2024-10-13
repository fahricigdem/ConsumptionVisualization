var localStorageHelper = {};

localStorageHelper.getData = function (key) {
    return localStorage.getItem(key);
}
localStorageHelper.saveData = function (key, value) {
        localStorage.setItem(key, value);
}
localStorageHelper.removeData = function (key) {
    return localStorage.removeItem(key);
}

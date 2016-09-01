Date.prototype.toLocaleDateString = function (DatePattern) {
    //重写toLocaleDateString方法，来固定输出格式，兼容多个浏览器
    if (/yyyy.MM.dd/.test(DatePattern)) {
        DatePattern = DatePattern.replace("yyyy", this.getFullYear()).replace("MM", this.getMonth() + 1).replace("dd", this.getDay());
        return DatePattern;
    }
    return this.toLocaleString();
};
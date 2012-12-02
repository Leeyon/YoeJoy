/**
* YoeJoy Admin.js file
*/

/** ************************************************************************************************** */

YoeJoy.Site = new function () {

    var _this = this;

    _this.Utility = new function () {

        var _this = this;

        _this.GetQueryString = function (para) {
            var reg = new RegExp("(^|&)" + para + "=([^&]*)(&|$)", "i");
            var r = window.location.search.substr(1).match(reg);
            if (r != null) {
                return unescape(r[2]);
            }
            return null;
        }

        _this.ReplaceEmptyItem = function (arr) {
            for (var i = 0, len = arr.length; i < len; i++) {
                if (!arr[i] || arr[i] == '') {
                    arr.splice(i, 1);
                    len--;
                    i--;
                }
            }
            return arr;
        }

    };

};
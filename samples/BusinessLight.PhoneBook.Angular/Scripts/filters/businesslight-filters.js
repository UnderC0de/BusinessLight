angular.module("customFilters", [])
.filter("unique", function () {
    return function (data, propertyName) {
        // Filters 'data' items, returnin a list of unique values for 'propertyName'
        if (angular.isArray(data) && angular.isString(propertyName)) {
            var results = [];
            var keys = {};
            for (var i = 0; i < data.length; i++) {
                var val = data[i][propertyName];
                if (angular.isUndefined(keys[val])) {
                    keys[val] = true;
                    results.push(val);
                }
            }
            return results;
        } else {
            return data;
        }
    }
})
.filter("labelCase", function () {
    return function (value, reverse) {
        if (angular.isString(value)) {
            var intermediate = reverse ? value.toUpperCase() : value.toLowerCase();
            return (reverse ? intermediate[0].toLowerCase() :
            intermediate[0].toUpperCase()) + intermediate.substr(1);
        } else {
            return value;
        }
    };
})
.filter("skip", function () {
    return function (data, count) {
        if (angular.isArray(data) && angular.isNumber(count)) {
            if (count > data.length || count < 1) {
                return data;
            } else {
                return data.slice(count);
            }
        } else {
            return data;
        }
    }
}).filter("take", function ($filter) {
    return function (data, skipCount, takeCount) {
        var skippedData = $filter("skip")(data, skipCount);
        return $filter("limitTo")(skippedData, takeCount);
    }
});


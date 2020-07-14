"use strict";

var gulp = require('gulp'),
    rimraf = require("rimraf"),
    concat = require("gulp-concat"),
    cssmin = require("gulp-cssmin"),
    uglify = require("gulp-uglify");
var merge = require('merge-stream');

//var paths = {
//    webroot: "./wwwroot/"
//};

var depscss = {
    "bootstrap": {
        "dist/css/bootstrap.min.css": ""
    }
};

var depsjs = {
    "bootstrap": {
        "dist/js/bootstrap.min.js": ""
    },
    "axios": {
        "dist/axios.min.js": ""
    }
};

gulp.task("clean", function (cb) {
    return rimraf("wwwroot/lib/", cb);
});

gulp.task("js", function () {
    var streams = [];

    for (var prop in depsjs) {
        console.log("Hello gulp depsjs: " + prop);
        for (var itemProp in depsjs[prop]) {
            streams.push(gulp.src("node_modules/" + prop + "/" + itemProp)
                .pipe(gulp.dest("Scripts/" + depsjs[prop][itemProp])));
        }
    }
    return merge(streams);
});

gulp.task("css", function () {
    var streams = [];

    for (var prop in depscss) {
        console.log("Hello gulp depscss: " + prop);
        for (var itemProp in depscss[prop]) {
            streams.push(gulp.src("node_modules/" + prop + "/" + itemProp)
                .pipe(gulp.dest("Content/" + depscss[prop][itemProp])));
        }
    }
    return merge(streams);
});

gulp.task("scripts", gulp.series(["js", "css"]));
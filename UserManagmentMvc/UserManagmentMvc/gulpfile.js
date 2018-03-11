/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');
var _ = require('lodash');

gulp.task('defaul', function () {


    var js = {
        js: [
            './wwwroot/lib/jquery/dist/jquery.min.js',
            './wwwroot/lib/bootstrap/dist/js/bootstrap.min.js',
            './wwwroot/lib/jquery-datetimepicker/dist/jquery.datetimepicker.ByGiro.js',
            './wwwroot/lib/jquery-validate/dist/jquery.validate.min.js',
            './wwwroot/lib/jquery-validate/dist/additional-methods.min',
            './wwwroot/lib/jquery-validation-unobtrusive/jquery.validate.unobtrusive.min.js'

        ],

        css: [
            './wwwroot/lib/bootstrap/dist/css/bootstrap.css',           
            './wwwroot/lib/jquery-datetimepicker/dist/jquery.datetimepicker.ByGiro.min.css'
        ]
    };
    (js.js).forEach(function (js, type) {
        gulp.src(js).pipe(gulp.dest('./Scripts'));
    });

    (js.css).forEach(function (js, type) {
        gulp.src(js).pipe(gulp.dest('./Content'));
    });




});
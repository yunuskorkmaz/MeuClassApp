var gulp = require('gulp');
var sass = require('gulp-sass');
var prefix = require('gulp-autoprefixer')
var plumber = require('gulp-plumber')
var browsersync = require('browser-sync').create();

const reload = browsersync.reload;

gulp.task('browser', function () {
    var files = [
        'Scripts/**/*.js',
        'Content/**/*.css',
        'Content/**/*.js',
        'Views/**/*.cshtml'
    ];

    browsersync.init(files, {
        notify: false,
        proxy: "http://localhost:55007/"
    });

    gulp.watch('./Content/sass/**/*.scss', ['css', 'css2']);

    gulp.watch('./Views/**/*.cshtml', ['html']);

    gulp.watch('./Content/**/*.js', reload);

})


gulp.task('css', function () {

    return gulp.src('./Content/sass/main.scss')
        .pipe(plumber([{
            errorHandler: false
        }]))
        .pipe(sass())
        .pipe(gulp.dest('./Content/css/'))
        .pipe(browsersync.stream())
});

gulp.task('css2', function () {
    return gulp.src('./Content/sass/LoginMain.scss')
        .pipe(plumber([{
            errorHandler: false
        }]))
        .pipe(sass())
        .pipe(gulp.dest('./Content/css'))
        .pipe(browsersync.stream())
});

gulp.task('html', function () {
    return gulp.src('./Views/**/*.cshtml')
        .on('end', reload);
});

gulp.task('default', ['browser', 'html', 'css']);
const { watch, series, src, dest } = require('gulp');
const sass = require('gulp-sass')(require('sass'));
const clean = require('gulp-clean');

function cleanup() {
    return src('../wwwroot/css/*', { read: false })
        .pipe(clean({ force: true }));
}

function styles() {
    return src('src/css/*.scss')
        .pipe(sass())
        .pipe(dest('../wwwroot/css'));
}

function statics() {
    return src('static_assets/**/*')
        .pipe(dest('../wwwroot/'));
}

function run() {
    watch('./src/css/*.scss', styles);
    watch(['./static_assets/**/*', './static_assets/*.*'], statics);
}

exports.styles = styles;
exports.statics = statics;
exports.run = run;
exports.default = series(cleanup, statics, styles);

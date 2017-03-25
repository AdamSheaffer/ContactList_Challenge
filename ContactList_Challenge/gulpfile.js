var gulp = require("gulp");
var sourcemaps = require("gulp-sourcemaps");
var babel = require("gulp-babel");

var config = {
    dest: {
        js: "wwwroot/js/dist",
        lib: "wwwroot/lib/"
    }
}

var browserDeps = [
    { dest: "angular", source: "angular/**/*" },
    { dest: "angular-animate", source: "angular-animate/**/*" },
    { dest: "angular-aria", source: "angular-aria/**/*" },
    { dest: "angular-material", source: "angular-material/**/*" },
    { dest: "angular-messages", source: "angular-messages/**/*" },
    { dest: "babel", source: "babel-polyfill/**/*" },
    { dest: "systemjs", source: "systemjs/**/*" },
];

gulp.task("default", function () {
    return gulp.src("wwwroot/js/src/**/*.js")
      .pipe(sourcemaps.init())
      .pipe(babel())
      .pipe(sourcemaps.write("."))
      .pipe(gulp.dest(config.dest.js));
});

gulp.task("copyBrowserDeps", function () {
    browserDeps.forEach(function (lib) {
        gulp.src("./node_modules/" + lib.source)
            .pipe(gulp.dest(config.dest.lib + lib.dest));
    });
});

gulp.task("watch", function () {
    gulp.watch("wwwroot/js/src/**/*.js", ["default"]);
    gulp.watch("wwwroot/js/src/**/*.html", ["templates"]);
});

gulp.task("templates", function () {
    return gulp.src("wwwroot/js/src/**/*.html")
      .pipe(gulp.dest("wwwroot/js/dist"))
});
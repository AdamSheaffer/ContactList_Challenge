System.config({
    baseURL: "wwwroot/",
    map: {
        "angular-animate": "lib/angular-animate/angular-animate.js",
        "angular-aria": "lib/angular-aria/angular-aria.js",
        "angular-material": "lib/angular-material/angular-material.js",
        "babel-polyfill": "lib/babel/dist/polyfill.js",
        "app": "js/dist",
        "components": "js/dist/components",
        "services": "js/dist/services",
        "npm": "../node_modules"
    },
    meta: {
        "angular-material": {
            deps: ["angular-animate", "angular-aria"]
        }
    }
});
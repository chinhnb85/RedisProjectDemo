({
    baseUrl: "../Js",
    mainConfigFile: "../Js/config.js",
    name: 'main',
    out: '../build/main.min.js',
    preserveLicenseComments: false,
    paths: {
        requireLib: '../Js/require'
    },
    include: 'requireLib'
    // optimize: "none"
})
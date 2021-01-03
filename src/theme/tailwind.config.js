const plugin = require('tailwindcss/plugin')

module.exports = {
    theme: {
        fontFamily: {
            'serif': ['Merriweather', 'ui-serif', 'Georgia']
        },
    },
    variants: {
        fontSize: ({ after }) => after(['first-letter']),
        float: ({ after }) => after(['first-letter']),
        padding: ({ after }) => after(['first-letter']),
        textColor: ({ after }) => after(['first-letter']),
    },
    plugins: [
        plugin(function ({ addVariant, e }) {
            addVariant('first-letter', ({ modifySelectors, separator }) => {
                modifySelectors(({ className }) => {
                    return `.${e(`first-letter${separator}${className}`)}:first-letter`
                })
            })
        }),
    ],
}

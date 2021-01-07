const plugin = require('tailwindcss/plugin')
const colors = require('tailwindcss/colors')

module.exports = {
    theme: {
        fontFamily: {
            'serif': ['Merriweather', 'ui-serif', 'Georgia']
        },
        extend: {
            zIndex: {
                '-10': '-10',
            },
            width: {
                '2full': '200%',
            }
        },
        colors: {
            palette1: '#D7F2BA',
            palette2: '#BDE4A8',
            palette3: '#9CC69B',
            palette4: '#79B4A9',
            palette5: '#676F54',
            gray: colors.coolGray,
            white: colors.white
        }
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

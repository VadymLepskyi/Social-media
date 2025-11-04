// module.exports = {
//   plugins: {
//     'postcss-import': {},
//     '@tailwindcss/postcss7-compat': {}, // Use the compat plugin
//     autoprefixer: {},
//   },
// };
module.exports = {
  plugins: {
    'postcss-import': {},
    'postcss-flexbugs-fixes': {},          // <-- make sure this is here
    'tailwindcss': {},                     // or '@tailwindcss/postcss7-compat'
    'autoprefixer': {},
  },
};

/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./../**/*.{razor,html,cshtml}"],
  theme: {
    extend: {},
  },
  plugins: [
    require('@tailwindcss/forms'),
    require('@tailwindcss/typography')
  ],
}


/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./src/**/*.{js,jsx,ts,tsx}"], // Scan all TSX files
  theme: {
    extend: {
      colors: {
        'padel-primary': '#1f3a93',
        'padel-accent': '#10b981',
        'padel-light': '#f8fafc',
      },
      fontFamily: {
        Inter: ['Inter', 'sans-serif'],
      },
    },
  },
  plugins: [],
}


/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./src/**/*.{js,jsx,ts,tsx}", // Files to scan for Tailwind classes
  ],
  theme: {
    extend: {
      colors: {
                        'padel-primary': '#1f3a93', // Deep Indigo Blue (The primary color)
                        'padel-accent': '#10b981', // Emerald 500 - Vibrant Green (The accent color)
                        'padel-light': '#f8fafc', // Slate 50 - Off-white background
                    },
                    fontFamily: {
                        sans: ['Inter', 'sans-serif'],
                    },
    }, // You can add custom colors, spacing, fonts here
  },
  plugins: [], // Add Tailwind plugins here if needed
};

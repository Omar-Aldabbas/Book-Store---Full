/** @type {import('tailwindcss').Config} */
module.exports = {
  mode: "jit",

  content: ["./src/**/*.{html,ts}"],
  darkMode: "class",
  theme: {
    extend: {
      colors: {
        primary: "var(--primary)",
        secondary: "var(--secondary)",
        accent: "var(--accent)",
        background: "var(--background)",
        text: "var(--text)",
        icon: "var(--icon)",
        violet: "var(--violet)",
        violetb: "var(--violetb)",
        violetb2: "var(--violetb2)",
      },
    },
  },
  plugins: [],
};

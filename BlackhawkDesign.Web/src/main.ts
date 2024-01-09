import { createApp } from "vue";
import { createVuetify } from "vuetify";
import { createCoalesceVuetify } from "coalesce-vue-vuetify3";
import { AxiosClient as CoalesceAxiosClient } from "coalesce-vue";
import { aliases, fa } from "vuetify/iconsets/fa";
import { mdi } from "vuetify/lib/iconsets/mdi";
// make sure to also import the coresponding css
import "@mdi/font/css/materialdesignicons.css"; // Ensure you are using css-loader
import "@fortawesome/fontawesome-free/css/all.css"; // Ensure your project is capable of handling css files

import App from "./App.vue";
import router from "./router";

// Import global CSS and Fonts:
import "typeface-roboto";
import "@fortawesome/fontawesome-free/css/all.css";
import "coalesce-vue-vuetify3/styles.css";
import "@/site.scss";
import "vuetify/styles";
import "material-design-icons-iconfont/dist/material-design-icons.css";
import "@mdi/font/css/materialdesignicons.css";

import $metadata from "@/metadata.g";
// viewmodels.g has side effects - it populates the global lookup on ViewModel and ListViewModel.
// This global lookup allows the admin page components to function.
import "@/viewmodels.g";

// SETUP: vuetify
const inputDefaults = { density: "compact", variant: "outlined" };
const vuetify = createVuetify({
  icons: {
    defaultSet: "fa",
    aliases,
    sets: {
      mdi,
      fa,
    },
  },
  defaults: {
    VTextField: inputDefaults,
    VTextarea: inputDefaults,
    VSelect: inputDefaults,
    VCombobox: inputDefaults,
    VAutocomplete: inputDefaults,
    VField: inputDefaults,
    VInput: inputDefaults,
    VSwitch: { color: "primary" }, // https://github.com/vuetifyjs/vuetify/issues/16486
  },
  theme: {
    defaultTheme: "dark",
    themes: {
      dark: {
        colors: {
          primary: "#811618",
        },
      },
      light: {
        colors: {
          primary: "#811618",
        },
      },
    },
  },
});

// SETUP: coalesce-vue
CoalesceAxiosClient.defaults.baseURL = "/api";
CoalesceAxiosClient.defaults.withCredentials = true;

// SETUP: coalesce-vue-vuetify
const coalesceVuetify = createCoalesceVuetify({
  metadata: $metadata,
});

const app = createApp(App);
app.use(router);
app.use(vuetify);
app.use(coalesceVuetify);
app.mount("#app");

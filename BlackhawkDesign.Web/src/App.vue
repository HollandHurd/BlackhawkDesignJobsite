<template>
<div class="app">

  <v-app id="vue-app" >
    <v-app-bar color="primary">
      <router-link to="/" style="color: inherit">
        <h2 class="title">Blackhawk Design</h2>
      </router-link>
      
      <v-toolbar-title>
        <router-link to="/" style="color: inherit">
          <img src="./assets/logo.png"
               width="64"
               height="64"
               alt="Blackhawk Design Logo" />
        </router-link>
        
      </v-toolbar-title>
      <v-btn href="/">Home</v-btn>
      <v-btn href="/jobs">Jobs</v-btn>
      <v-btn href="/apply">Apply</v-btn>
      
      <v-app-bar-nav-icon @click.stop="drawer = !drawer" />
      <v-btn class="toggleTheme" @click=toggleTheme variant="flat" icon="mdi-home">t</v-btn>

    </v-app-bar>
    <v-navigation-drawer v-model="drawer" temporary
        location="top">
      <v-list>
        <v-list-item link to="/">

          <v-list-item-title>Home</v-list-item-title>
          <template #prepend>
            <v-icon>fas fa-home</v-icon>
          </template>
        </v-list-item>
        <v-list-item link to="/jobs">
          <template #prepend>
            <v-icon>fas fa-bell</v-icon>
          </template>
          <v-list-item-title>Jobs</v-list-item-title>
        </v-list-item>
        <v-list-item link to="/apply">
          <template #prepend>
            <v-icon>fas fa-cubes</v-icon>
          </template>
          <v-list-item-title>Apply</v-list-item-title>
        </v-list-item>
        <v-list-item link to="/admin">
          <template #prepend>
            <v-icon>fas fa-cogs</v-icon>
          </template>
          <v-list-item-title>Admin Pages</v-list-item-title>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>

    <v-main>
      <!-- https://stackoverflow.com/questions/52847979/what-is-router-view-key-route-fullpath -->
      <router-view v-slot="{ Component, route }">
        <transition name="router-transition" mode="out-in" appear>
          <component :is="Component" :key="route.path" />
        </transition>
      </router-view>
    </v-main>

  </v-app>
</div>
</template>

<script setup lang="ts">
import { useTheme } from "vuetify";

const drawer = ref<boolean | null>(null);
const theme = useTheme();

function toggleTheme() {
  theme.global.name.value = theme.global.current.value.dark ? "light" : "dark";
}
</script>

<style lang="scss">
  .app {
    .v-app-bar-nav-icon {
      display: none;
    }

    .v-navigation-drawer {
      display: none;
    }

    .drawer {
      display: none;
    }

    @media screen and (max-width: 700px) {
      .v-btn {
        display: none;
      }

      .v-app-bar-nav-icon,
      .toggleTheme {
        display: inherit;
      }

      .v-navigation-drawer {
        display: list-item;
      }
    }

    @media screen and (min-width: 701px) {
      .v-btn {
        display: inherit;
      }

      .v-app-bar-nav-icon {
        display: none;
      }

      .toggleTheme {
        display: inherit;
      }

      .v-navigation-drawer {
        display: none;
      }
    }
  }
</style>
<template>
  <v-app id="vue-app">
    <v-app-bar color="primary">
      <v-app-bar-nav-icon @click.stop="drawer = !drawer" />
      <v-toolbar-title>
        <router-link to="/" style="color: inherit">
          Blackhawk Design
          <img
            src="./assets/logo.png"
            width="64"
            height="64"
            alt="Blackhawk Design Logo"
          />
        </router-link>
      </v-toolbar-title>
      <v-btn @click=toggleTheme variant="flat" icon="mdi-home">t</v-btn>
    </v-app-bar>
    <v-navigation-drawer v-model="drawer">
      <v-list>
        <v-list-item link to="/">
          <template #prepend>
            <v-icon>fas fa-home</v-icon>
          </template>
          <v-list-item-title>Home</v-list-item-title>
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
.router-transition-enter-active,
.router-transition-leave-active {
  transition: 0.1s ease-out;
}

.router-transition-enter-from,
.router-transition-leave-to {
  opacity: 0;
}
</style>

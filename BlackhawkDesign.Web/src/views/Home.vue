<template>
  <v-parallax
    src="../assets/homepage.png"
  >
    <div class="d-flex flex-column fill-height justify-center align-center text-white">
      
      <h1 class="test">
        Blackhawk Design
        <img src="../assets/logo.png"
             width="64"
             height="64"
             alt="Blackhawk Design Logo" />
      </h1>
      <h4 class="subheading">
        Empowering the body of CHS!
      </h4>
    </div>
  </v-parallax>
  <div class="mission">

    <v-card
    class="mx-auto my-12"
    max-width="300"
    
  >

    <v-img
      cover
      height=250
      src="../assets/missionStatement.png"
    ></v-img>

    <v-card-item>
      <v-card-title>Our Mission</v-card-title>
    </v-card-item>

    <v-card-text>
      This website is mainly used for the student body of Cheney High School.
      Our primary objective is to provide students the opportunity to look at available jobs and learn how they can benefit from our resources.
      We evaluate who fits the qualifications for our jobs based on job screenings and skill checks as a precaution to better our business and quality of production.
    </v-card-text>


  </v-card>
  </div>
  <div class="skills">
    
  </div>
  <div class="faq">
    <h1 align="center">Frequently Asked Questions</h1>
    <v-expansion-panels variant="popout" class="my-4">
      <v-expansion-panel
        v-for="i in 3"
        :key="i"
        title="Item"
        text="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat."
      ></v-expansion-panel>
    </v-expansion-panels>
    
  </div>
  <Footer></Footer>
</template>

<script setup lang="ts">
useTitle("Home");
</script>

<style setup="scss">


.home {
  height: 1080px;
  text-align: center;

}

.mission {
  height: 550px;
}

.test {
  font-family: 'Times New Roman', Times, serif
}


</style>

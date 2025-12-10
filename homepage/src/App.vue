<template>
  <div id="app">
    <!-- 导航栏 -->
    <Navbar />
    
    <!-- 主要内容 -->
    <main>
      <!-- 英雄区域 -->
      <HeroSection />
      
      <!-- 功能特性 -->
      <FeaturesSection />
      
      <!-- 产品截图 -->
      <ScreenshotsSection />
      
      <!-- 下载区域 -->
      <DownloadSection />
      
      <!-- 使用说明 -->
      <GuideSection />
    </main>
    
    <!-- 页脚 -->
    <Footer />
  </div>
</template>

<script>
import Navbar from './components/Navbar.vue'
import HeroSection from './components/HeroSection.vue'
import FeaturesSection from './components/FeaturesSection.vue'
import ScreenshotsSection from './components/ScreenshotsSection.vue'
import DownloadSection from './components/DownloadSection.vue'
import GuideSection from './components/GuideSection.vue'
import Footer from './components/Footer.vue'

export default {
  name: 'App',
  components: {
    Navbar,
    HeroSection,
    FeaturesSection,
    ScreenshotsSection,
    DownloadSection,
    GuideSection,
    Footer
  }
}
</script>

using System;
using Xunit;

namespace Itminus.Feature.Test
{
    public class UnitTest1
    {
        [Fact]
        public void TestBasicInterface()
        {
            var features= new FeatureCollection();
            var dummy= new Dummy();
            features[typeof(IDummy)]=dummy; 
            Assert.Equal(dummy,features[typeof(IDummy)]);
        }

        [Fact]
        public void TestIndex()
        {
            var features= new FeatureCollection();
            var dummy1= new Dummy();
            var dummy2= new Dummy();
            features[typeof(IDummy)]=dummy1; 
            Assert.Equal(dummy1,features[typeof(IDummy)]);
            features[typeof(IDummy)]=dummy2; 
            Assert.Equal(dummy2,features[typeof(IDummy)]);
        }


        [Fact]
        public void TestGetSet()
        {
            var features= new FeatureCollection();
            var dummy0=new Dummy();
            var dummy1=new Dummy();
            var dummy2=new Dummy();
            features.Set<IDummy>(dummy0);
            features.Set<Dummy>(dummy1);
            features.Set<Dummy>(dummy2);
            Assert.Equal(features.Get<IDummy>(),dummy0);
            Assert.NotEqual(features.Get<Dummy>(),dummy1);
            Assert.Equal(features.Get<Dummy>(),dummy2);
        }

        [Fact]
        public void TestIndexAndGetSet()
        {
            var features= new FeatureCollection();
            var dummy0=new Dummy();
            var dummy1=new Dummy();
            var dummy2=new Dummy();
            features.Set<IDummy>(dummy0);
            features[typeof(Dummy)]=dummy1;
            Assert.Equal(features.Get<Dummy>(),dummy1);
            features.Set<Dummy>(dummy2);
            Assert.Equal(features.Get<IDummy>(),dummy0);
            Assert.NotEqual(features.Get<Dummy>(),dummy1);
            Assert.Equal(features.Get<Dummy>(),features[typeof(Dummy)]);
            Assert.Equal(features.Get<Dummy>(),dummy2);
        }

        [Fact]
        public void TestDefaultFeatures()
        {
            var defaultFeatues= new FeatureCollection();
            var dummy0=new Dummy();
            var dummy1=new Dummy();
            defaultFeatues.Set<IDummy>(dummy0);
            defaultFeatues.Set<Dummy>(dummy1);

            var dummy= new Dummy();
            var features = new FeatureCollection(defaultFeatues);
            features.Set<IDummy>(dummy);
            Assert.Equal(features.Get<IDummy>(),dummy);
            Assert.Equal(features.Get<Dummy>(),dummy1);
        }

    }
}

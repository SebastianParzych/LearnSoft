import React from 'react';
import {
 RefreshControl, StyleSheet, Text, SafeAreaView, Image, View, FlatList, Dimensions, ToastAndroid, Button
} from 'react-native';
import LogoComponent from './../components/Logo'
import ActionButton from './../components/ActionButton'
const widthConst = Dimensions.get('screen').width;

export default function CourseInfoScreen({ route, navigation }) {
  console.log("COURSEINFO SCREEEEN",route.params)
  // const MenuList = [
  //   {
  //     id: "1",
  //     title: "Profil",
  //     screen: "CourseData"
  //   },
  // ];
  // console.log(route.params)

  return (

      <SafeAreaView style={styles.container}>
          <Text>
            WITAM
          </Text>
               
    </SafeAreaView>

  );
}


const styles = StyleSheet.create({
  container: {
    flex: 1,
    alignItems: 'center',
    justifyContent: 'center',
  //  color: 'white',
  },
  list: {
    alignItems: 'center',
    justifyContent: 'center',
    width: widthConst,
    flex: 1
  },
  enappdWrapper: {
    position: 'absolute',
    bottom: 0
  },

  item: {
    marginTop: 0,
    width: 300,
   // backgroundColor: 'white',
    flexDirection: 'row',
    alignItems: 'flex-start',
    paddingHorizontal: 5,
    padding: 5 ,
    borderWidth: 1, 

  },
  itemText: {
    textAlign: 'center', // <-- the magic
    fontWeight: 'bold',
    fontSize: 24,
    marginTop:20,
    width: 300,
  //  backgroundColor: 'white',

  }
});
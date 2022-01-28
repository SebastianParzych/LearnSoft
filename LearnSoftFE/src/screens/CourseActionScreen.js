import React from 'react';
import {
  RefreshControl, StyleSheet, Text, SafeAreaView, Image, View, FlatList, Dimensions, ToastAndroid, Button
} from 'react-native';
import LogoComponent from './../components/Logo'
import ActionButton from './../components/ActionButton'
const widthConst = Dimensions.get('screen').width;

export default function CourseActionScreen({ route, navigation }) {

    const user = route.params.user;
    const course = route.params.props;
  const MenuList = [
      {
      id: "1",
      title: "Informacje",
      screen: "CourseInfoScreen"
    },
    {
      id: "2",
      title: "Zadania",
      screen: "UnImplementedScreen"
    },
    {
      id: "3",
      title: "Zaliczenia",
      screen: "UnImplementedScreen"
    },
    {
      id: "4",
      title: "Materiały",
      screen: "UnImplementedScreen"
    },
    {
      id: "5",
      title: "Dołącz do grupy",
      screen: "UnImplementedScreen"
    },
    {
      id: "6",
      title: "Postępy w nauce",
      screen: "UnImplementedScreen"
    },
    {
      id: "7",
      title: "Oceny",
      screen: "UnImplementedScreen"
    }
    

  ];

  function Item({ title , screen  }) {
    return (
      <ActionButton
           text = {title}
           onPress={ () =>{navigation.navigate(screen,{user,course})}}
      ></ActionButton> 

    );
  }
  return (

      <SafeAreaView style={styles.container}>
          <LogoComponent header={course.name}/>
      <FlatList
        data={MenuList}
        renderItem={({ item }) => <Item title={item.title} screen= {item.screen} />}
        contentContainerStyle={styles.list}
      />
      <View style={styles.enappdWrapper}>
      </View>
               
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
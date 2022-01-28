import React from 'react';
import {
  RefreshControl, StyleSheet, Text, SafeAreaView, Image, View, FlatList, Dimensions, ToastAndroid, Button
} from 'react-native';
import LogoComponent from './../components/Logo'
import ActionButton from './../components/ActionButton'
const widthConst = Dimensions.get('screen').width;

export default function App({ route, navigation }) {
 
  const MenuList = [
    {
      id: "1",
      title: "Profil",
      screen: "Profile"
    },
    {
      id: "2",
      title: "Przedmioty",
      screen: "Courses"
    },
    {
      id: "3",
      title: "Plan zajęć",
      screen: "Schedule"
    },
    {
      id: "4",
      title: "Kalendarz",
      screen: "Calendar"
    },
    {
      id: "5",
      title: "Społeczność",
      screen: "Society"
    },
    {
      id: "6",
      title: "Oceny",
      screen: "Grades"
    }
    

  ];

  const [listData, setListData] = React.useState(MenuList);

  function Item({ title , screen  }) {

    return (
      <ActionButton
           text = {title}
           onPress={ () =>{navigation.navigate(screen,route.params.userData)}}
      ></ActionButton> 

    );
  }
  return (

      <SafeAreaView style={styles.container}>
          <LogoComponent header='Menu'/>

      <FlatList
        data={listData}
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
import * as React from 'react';
import {
  RefreshControl, StyleSheet, Text, SafeAreaView, Image, View, FlatList, Dimensions, ToastAndroid, Button
} from 'react-native';
import { NavigationContainer } from '@react-navigation/native';
import { createNativeStackNavigator } from '@react-navigation/native-stack';
import LogoComponent from './../components/Logo'
import ActionButton from './../components/ActionButton'
import api from './../api/ApiCaller'

const widthConst = Dimensions.get('screen').width;

export default  function CoursesScreen({ route, navigation }) {
    const user = route.params;

  const [listData, setListData] = React.useState([]);
  
    React.useEffect(() => {
      api.callCoursesList({"userid":user.userId})
     .then((response) => response.json())
      .then((responseJson) => {
          setListData(responseJson)
      })
      .catch((error) => {
        alert(error);
      }); 
  }, [])
  function Item({ props }) {
    return (
      <ActionButton
           text = {props.name}
           onPress={ () =>{navigation.navigate('CourseActionScreen',{user,props})}}
      ></ActionButton> 
    );
  }
 return (
      <SafeAreaView style={styles.container}>
          <LogoComponent header='Menu'/>
      <FlatList
        data={listData}
        renderItem={({ item }) => <Item props={item} />}
        contentContainerStyle={styles.list}
           keyExtractor={item => item.courseId}
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